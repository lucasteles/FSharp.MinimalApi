[![CI](https://github.com/lucasteles/FSharp.MinimalApi/actions/workflows/ci.yml/badge.svg)](https://github.com/lucasteles/FSharp.MinimalApi/actions/workflows/ci.yml)
[![Nuget](https://img.shields.io/nuget/v/FSharp.MinimalApi.svg?style=flat)](https://www.nuget.org/packages/FSharp.MinimalApi)

# FSharp.MinimalApi 

Easily define your routes in your [ASP.NET Core MinimalAPI](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis) with [`TypedResults`](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-7.0#typed-results-for-minimal-apis) support

> **⚠️** This library is in beta state

## Getting started

[NuGet package](https://www.nuget.org/packages/FSharp.MinimalApi) available:

```ps
$ dotnet add package FSharp.MinimalApi
```

> **💡** You can check a complete sample [HERE](https://github.com/lucasteles/FSharp.MinimalApi/tree/master/BasicApi)


## Defining Routes

```fsharp
open FSharp.MinimalApi
open type TypedResults

let routes =
    endpoints {

        get "/hello" (fun () -> "world")

        get "/inc/{v}" (fun (v: int)  -> v + 1)

        get "/secret" (fun () -> "I'm secret") (fun b -> b.ExcludeFromDescription())

        get "/double/{v}" produces<Ok<int>> (fun (v: int) -> Ok(v * 2))

        get "/even/{v}" produces<Ok<string>, BadRequest> (fun (v: int) (logger: ILogger<_>) ->
            (if v % 2 = 0 then
                // the `!>` is necessary for implicit conversions between result types
                 !! Ok("even number!") 
             else
                 logger.LogInformation $"Odd number: {v}"
                 !! BadRequest()))

        // RouteBuilder access
        set (fun b -> b.MapGet("/health", (fun () -> "healthy")))

        mapGroup "user" {
            tags "Users"
            allow_anonymous

            get "/" produces<Ok<User[]>> (fun (db: AppDbContext) ->
                task {
                    let! users = db.Users.ToArrayAsync()
                    return Ok(users)
                })

            get "/{userId}" produces<Ok<User>, NotFound> (fun (userId: Guid) (db: AppDbContext) ->
                task {
                    let! res = db.Users.Where(fun x -> x.Id = UserId userId).TryFirstAsync()

                    match res with
                    | Some user -> return !! Ok(user)
                    | None -> return !! NotFound()
                })

            post "/" produces<Created<User>, Conflict, ValidationProblem>
                (fun (userInfo: NewUser) (db: AppDbContext) ->
                    task {
                        match NewUser.validate userInfo with
                        | Error err -> return !! ValidationProblem(err)
                        | Ok() ->
                            let! exists = db.Users.TryFirstAsync(fun x -> x.Email = userInfo.Email)

                            match exists with
                            | Some _ -> return !! Conflict()
                            | None ->
                                let userId = Guid.NewGuid()

                                let newUser =
                                    { Id = UserId userId
                                        Name = userInfo.Name
                                        Email = userInfo.Email }

                                db.Users.add newUser
                                do! db.saveChangesAsync ()

                                return !! Created($"/user/{userId}", newUser)
                    })

            delete "/{userId}" produces<NoContent, NotFound> (fun (userId: Guid) (db: AppDbContext) ->
                task {
                    let! exists = db.Users.TryFirstAsync(fun x -> x.Id = UserId userId)

                    match exists with
                    | None -> return !! NotFound()
                    | Some user ->
                        db.Users.remove user
                        do! db.saveChangesAsync ()
                        return !! NoContent()
                })
        }
    }

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    // ... builder configuration ...
    app.MapGroup("api").WithTags("Root") |> routes.Apply |> ignore
    // ... app configuration ...
    app.Run()
    0
```
