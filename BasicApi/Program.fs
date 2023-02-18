open System
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
open type TypedResults


let routes =

    endpoints {

        // get "/hello" (fun () -> "world")

        get "/ping/{x}" (fun (x: int) -> $"pong {x}")
        //
        // get "/inc/{v:int}" (fun (v: int) (n: Nullable<int>) -> v + (n.GetValueOrDefault 1))
        //
        // // not working =/
        // get "/arg/{x}" (fun ([<FromRoute(Name = "x")>] v: int) -> $"pong {v}")
        //
        // // access route builder
        // get "/secret" (fun () -> "I'm secret") (fun b -> b.ExcludeFromDescription())
        //
        // // manual set builder config
        // set (fun b -> b.MapGet("/health", (fun () -> "healthy")))
        //
        // get "/double/{v}" produces<Ok<int>> (fun (v: int) -> Ok(v * 2))
        //
        // get "/even/{v}" produces<Ok<string>, BadRequest> (fun (v: int) (logger: ILogger<_>) ->
        //     (if v % 2 = 0 then
        //          !> Ok("even number!")
        //      else
        //          logger.LogInformation $"Odd number: {v}"
        //          !> BadRequest()))

        endpoints {
            group "user"

            get "/hello" (fun () -> "world")

        // tags "Users"

        // filter (fun ctx next ->
        //     task {
        //         if ctx.HttpContext.Request.Headers.Authorization.ToString() = "BAD" then
        //             return UnprocessableEntity() :> obj
        //         else
        //             return! next ctx
        //     })

        // get "/" produces<Ok<User[]>> (fun (db: AppDbContext) ->
        //     task {
        //         let! users = db.Users.ToArrayAsync()
        //         return Ok(users)
        //     })
        //
        // get "/{userId}" produces<Ok<User>, NotFound> (fun (userId: Guid) (db: AppDbContext) ->
        //     task {
        //         let! res = db.Users.Where(fun x -> x.Id = UserId userId).TryFirstAsync()
        //
        //         match res with
        //         | Some user -> return !> Ok(user)
        //         | None -> return !> NotFound()
        //     })

        // endpoints {
        //     group "profile"
        //     allow_anonymous
        //
        //     post
        //         "/"
        //         produces<Created<User>, Conflict, ValidationProblem>
        //         (fun (userInfo: NewUser) (db: AppDbContext) ->
        //             task {
        //                 match NewUser.validate userInfo with
        //                 | Error err -> return !> ValidationProblem(err)
        //                 | Ok() ->
        //                     let! exists = db.Users.TryFirstAsync(fun x -> x.Email = userInfo.Email)
        //
        //                     match exists with
        //                     | Some _ -> return !> Conflict()
        //                     | None ->
        //                         let userId = Guid.NewGuid()
        //
        //                         let newUser =
        //                             { Id = UserId userId
        //                               Name = userInfo.Name
        //                               Email = userInfo.Email }
        //
        //                         db.Users.add newUser
        //                         do! db.saveChangesAsync ()
        //
        //                         return !> Created($"/user/{userId}", newUser)
        //             })
        //
        //     delete "/{userId}" produces<NoContent, NotFound> (fun (userId: Guid) (db: AppDbContext) ->
        //         task {
        //             let! exists = db.Users.TryFirstAsync(fun x -> x.Id = UserId userId)
        //
        //             match exists with
        //             | None -> return !> NotFound()
        //             | Some user ->
        //                 db.Users.remove user
        //                 do! db.saveChangesAsync ()
        //                 return !> NoContent()
        //         })
        // }
        }
    }

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let jsonOptions = JsonFSharpOptions.Default()

    builder.Services
        .ConfigureHttpJsonOptions(fun c -> jsonOptions.AddToJsonSerializerOptions c.SerializerOptions)
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddTuples()
        .AddDbContext<AppDbContext>(
            (fun c -> c.UseInMemoryDatabase("basic_api") |> ignore),
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton
        )
    |> ignore

    let app = builder.Build()
    app.UseSwagger().UseSwaggerUI() |> ignore

    app.MapGroup("api").WithTags("Root") |> routes.Apply |> ignore

    app.Services.GetRequiredService<AppDbContext>().Database.EnsureCreated()
    |> ignore

    app.Run()
    0
