open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.FSharp.Core
open FSharp.MinimalApi
open Npgsql
open Dapper

type Person = { Id: int; Name: string }

let builder =  WebApplication.CreateBuilder args
let app = builder.Build()

let getConnection() =
    let conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=sample")
    conn.Open()
    conn

let otherConfig = configureApp {
    mapGet "/hello" (fun () -> "Hello world")
    mapGet "/bad" (fun () -> Results.BadRequest "baaaad")
} 
     
app {
    useConfiguration otherConfig
    
    mapGet "/person" (fun () ->
        use conn = getConnection()
        conn.Query<Person>("SELECT * FROM PERSON"))
   
    mapGet "/person/{id}" (fun (id: int) ->
        use conn = getConnection()
        conn.QuerySingle<Person>("SELECT * FROM PERSON WHERE ID = @ID", {|Id = id|}))
    
    mapPost "/person" (fun (person: Person) ->
        use conn = getConnection()
        conn.Execute("INSERT INTO PERSON(Name) VALUES(@Name)", {|Name = person.Name|}) |> ignore
        Results.Ok())
    
    mapPut "/person/{id}" (fun (id: int) (person: Person) ->
        use conn = getConnection()
        conn.Execute("UPDATE PERSON SET NAME = @Name WHERE ID = @Id", {| Name = person.Name
                                                                         Id = id |}) |> ignore
        Results.Ok())
    
    mapDelete "/person/{id}" (fun (id: int) ->
        use conn = getConnection()
        conn.Execute("DELETE FROM PERSON WHERE ID = @ID", {|Id = id|}) |> ignore
        Results.Ok())
}

app.Run()





















