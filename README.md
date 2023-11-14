[![CI](https://github.com/lucasteles/FSharp.MinimalApi/actions/workflows/ci.yml/badge.svg)](https://github.com/lucasteles/FSharp.MinimalApi/actions/workflows/ci.yml)
[![Nuget](https://img.shields.io/nuget/v/FSharp.MinimalApi.svg?style=flat)](https://www.nuget.org/packages/FSharp.MinimalApi)

# FSharp.MinimalApi 

Easily define your routes in your [ASP.NET Core MinimalAPI](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis) with [`TypedResults`](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-7.0#typed-results-for-minimal-apis) support

## Getting started

[NuGet package](https://www.nuget.org/packages/FSharp.MinimalApi) available:

```ps
$ dotnet add package FSharp.MinimalApi
```

> **💡** You can check a complete sample [HERE](https://github.com/lucasteles/FSharp.MinimalApi/tree/master/BasicApi)


## Defining Routes

```fsharp
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.HttpResults

open FSharp.MinimalApi
open FSharp.MinimalApi.Builder
open type TypedResults

type CustomParams =
    { [<FromRoute>]
      foo: int
      [<FromQuery>]
      bar: string
      [<FromServices>]
      logger: ILogger<MyDbContext> }

let routes =
    endpoints {
        get "/hello" (fun () -> "world")

        // request bindable parameters must be mapped to objects/records
        get "/ping/{x}" (fun (req: {| x: int |}) -> $"pong {req.x}")

        get "/inc/{v:int}" (fun (req: {| v: int; n: Nullable<int> |}) -> req.v + (req.n.GetValueOrDefault 1))

        get "/params/{foo}" (fun (param: CustomParams) ->
            param.logger.LogInformation "Hello Params"
            $"route={param.foo}; query={param.bar}")

        // better static/openapi typing
        get "/double/{v}" produces<Ok<int>> (fun (req: {| v: int |}) -> Ok(req.v * 2))

        get "/even/{v}" produces<Ok<string>, BadRequest> (fun (req: {| v: int; logger: ILogger<_> |}) ->
            (if req.v % 2 = 0 then
                 // TypedResult relies havely on implict convertions
                 // the (!!) operator help us to call the implicit cast
                 !! Ok("even number!")
             else
                 req.logger.LogInformation $"Odd number: {req.v}"
                 !! BadRequest()))
        
        // nesting
        endpoints {
            group "user"
            tags "Users"

            get "/" produces<Ok<User[]>> (fun (req: {| db: MyDbContext |}) ->
                task {
                    let! users = req.db.Users.ToArrayAsync()
                    return Ok(users)
                })

            get "/{userId}" produces<Ok<User>, NotFound> (fun (req: {| userId: Guid; db: MyDbContext |}) ->
                task {
                    let! res = req.db.Users.Where(fun x -> x.Id = UserId req.userId).TryFirstAsync()

                    match res with
                    | Some user -> return !! Ok(user)
                    | None -> return !! NotFound()
                })

            // group mappping
            routeGroup "profile" {
                allowAnonymous

                post
                    "/"
                    produces<Created<User>, Conflict, ValidationProblem>
                    (fun (req: {| userInfo: NewUser; db: MyDbContext |}) ->
                        task {
                            match NewUser.parseUser req.userInfo with
                            | Error err -> return !! ValidationProblem(err)
                            | Ok newUser ->
                                let! exists = req.db.Users.TryFirstAsync(fun x -> x.Email = newUser.Email)

                                match exists with
                                | Some _ -> return !! Conflict()
                                | None ->
                                    req.db.Users.add newUser
                                    do! req.db.saveChangesAsync ()
                                    return !! Created($"/user/{newUser.Id.Value}", newUser)
                        })

                delete "/{userId}" produces<NoContent, NotFound> (fun (req: {| userId: Guid; db: MyDbContext |}) ->
                    task {
                        let! exists = req.db.Users.TryFirstAsync(fun x -> x.Id = UserId req.userId)

                        match exists with
                        | None -> return !! NotFound()
                        | Some user ->
                            req.db.Users.remove user
                            do! req.db.saveChangesAsync ()
                            return !! NoContent()
                    })

            }
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
