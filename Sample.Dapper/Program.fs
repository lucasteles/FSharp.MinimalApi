open System
open System.Threading.Tasks
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.FSharp.Core
open FSharp.MinimalApi
open Npgsql
open Dapper

type Person = { Id: int; Name: string }
type OpenConnection = unit -> Task<NpgsqlConnection>
let builder =  WebApplication.CreateBuilder args

builder.Services.AddScoped<OpenConnection>(Func<_,_>(fun sp () ->
       task { let conn = new NpgsqlConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("Default"))
              do! conn.OpenAsync()
              return conn }) ) |> ignore

let app = builder.Build()

app {
    mapGet "/person" (fun (getConnection: OpenConnection) -> task {
        use! conn = getConnection()
        return! conn.QueryAsync<Person>("SELECT * FROM PERSON")
    })
    
    mapPost "/person" (fun (getConnection: OpenConnection) (person: Person) -> task {
        use! conn = getConnection()
        let! id = conn.ExecuteAsync("INSERT INTO PERSON(Name) VALUES(@Name) RETURNING ID", {|Name = person.Name|})
        return Results.Created($"/person/{id}", {person with Id = id})
    })
    
    mapGet "/person/{id:int}" (fun (getConnection: OpenConnection) (id: int) -> task {
        use! conn = getConnection()
        let! person = conn.QuerySingleOrDefaultAsync<Person>("SELECT * FROM PERSON WHERE ID = @ID", {|Id = id|})
        match Option.from person with
        | None -> return Results.NotFound()
        | Some _ -> return Results.Ok person
    })
    
    mapPut "/person/{id:int}" (fun (getConnection: OpenConnection) (id: int) (person: Person) -> task {
        use! conn = getConnection()
        let! n = conn.ExecuteAsync("UPDATE PERSON SET NAME = @Name WHERE ID = @Id", {| Name = person.Name; Id = id |}) 
        return if n > 0 then Results.NoContent() else Results.NotFound()
    })
    
    mapDelete "/person/{id:int}" (fun (getConnection: OpenConnection) (id: int) -> task {
        use! conn = getConnection()
        let! n = conn.ExecuteAsync("DELETE FROM PERSON WHERE ID = @ID", {|Id = id|})
        return if n > 0 then Results.NoContent() else Results.NotFound()
    })
}

app.Run()
