open System
open System.ComponentModel
open System.Linq
open System.Text.Json.Serialization
open BasicApi
open BasicApi.Db
open BasicApi.Models
open Microsoft.AspNetCore.Builder
open Microsoft.EntityFrameworkCore
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.HttpResults
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open FSharp.MinimalApi
open FSharp.MinimalApi.Swagger
open FSharp.MinimalApi.Builder
open Microsoft.Extensions.Options
open type TypedResults

let otherRoute =
    endpoints {
        group "other"

        get "union" (fun () ->
            match Random.Shared.Next(0, 3) with
            | 0 -> UnionValue.ANumber 42
            | 1 -> UnionValue.AString "Foo"
            | _ -> UnionValue.Nothing)
    }

let routes =
    endpoints {
        get "/hello" (fun () -> "world")

        get "/ping/{x}" (fun (x: int) -> $"pong {x}")

        get "/inc/{v:int}" (fun (v: int) (n: Nullable<int>) -> v + (n.GetValueOrDefault 1))

        // not working =/
        get "/arg/{x}" (fun ([<FromRoute(Name = "x")>] v: int) -> $"echo {v}")

        // access route builder
        get "/secret" (fun () -> "I'm secret") (fun b -> b.ExcludeFromDescription())

        // manual set builder config
        set (fun b -> b.MapGet("/health", (fun () -> "healthy")))


        // using options from DI
        get "/settings" (fun (options: IOptions<MyCustomSettings>) -> options.Value)

        get "/double/{v}" produces<Ok<int>> (fun (v: int) -> Ok(v * 2))

        endpoints {
            path "very" "long" "path" "dec"
            get "/" (fun (n: int) -> n - 1)
        }

        get "/even/{v}" produces<Ok<string>, BadRequest> (fun (v: int) (logger: ILogger<_>) ->
            (if v % 2 = 0 then
                 !! Ok("even number!")
             else
                 logger.LogInformation $"Odd number: {v}"
                 !! BadRequest()))

        otherRoute

        endpoints {
            group "user"
            tags "Users"

            filter (fun ctx next ->
                task {
                    if ctx.HttpContext.Request.Headers.Authorization.ToString() = "BAD" then
                        return UnprocessableEntity() :> obj
                    else
                        return! next ctx
                })

            get "/" produces<Ok<User[]>> (fun (db: MyDbContext) ->
                task {
                    let! users = db.Users.ToArrayAsync()
                    return Ok(users)
                })

            get "/{userId}" produces<Ok<User>, NotFound> (fun (userId: Guid) (db: MyDbContext) ->
                task {
                    let! res = db.Users.Where(fun x -> x.Id = UserId userId).TryFirstAsync()

                    match res with
                    | Some user -> return !! Ok(user)
                    | None -> return !! NotFound()
                })

            routeGroup "profile" {
                allowAnonymous

                post
                    "/"
                    produces<Created<User>, Conflict, ValidationProblem>
                    (fun (userInfo: NewUser) (db: MyDbContext) ->
                        task {
                            match NewUser.parseUser userInfo with
                            | Error err -> return !! ValidationProblem(err)
                            | Ok newUser ->
                                let! exists = db.Users.TryFirstAsync(fun x -> x.Email = newUser.Email)

                                match exists with
                                | Some _ -> return !! Conflict()
                                | None ->
                                    db.Users.add newUser
                                    do! db.saveChangesAsync ()
                                    return !! Created($"/user/{newUser.Id.Value}", newUser)
                        })

                delete "/{userId}" produces<NoContent, NotFound> (fun (userId: Guid) (db: MyDbContext) ->
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
    }

// basic support for option, single union and fieldless unions (for appsettings)
TypeDescriptor.addUnionTypesInAssemblyContaining<MyDbContext>
TypeDescriptor.addDefaultOptionTypes ()

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let jsonFsharp = JsonFSharpOptions.Default()

    builder.Services
        .ConfigureHttpJsonOptions(fun c -> jsonFsharp.AddToJsonSerializerOptions c.SerializerOptions)
        .AddSingleton(jsonFsharp)
        .AddEndpointsApiExplorer()
        .AddSwaggerGen(fun o -> o.ConfigureFSharp())
        .AddTuples()
        .AddDbContext<MyDbContext>(
            (fun c -> c.UseInMemoryDatabase("basic_api") |> ignore),
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton
        )
    |> ignore

    builder.Services
        .AddOptions<MyCustomSettings>()
        .BindConfiguration("MyCustomSettings")
        .ValidateOnStart()
    |> ignore

    let app = builder.Build()
    app.UseSwagger().UseSwaggerUI() |> ignore

    app.MapGroup("api").WithTags("Root") |> routes.Apply |> ignore

    app.Services.GetRequiredService<MyDbContext>().Database.EnsureCreated()
    |> ignore

    app.Run()
    0
