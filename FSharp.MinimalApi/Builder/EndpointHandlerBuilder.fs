namespace FSharp.MinimalApi.Builder

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open FSharp.MinimalApi
open Microsoft.AspNetCore.Routing

[<AbstractClass>]
type RouterBaseBuilder<'state>() =
    abstract Append: 'state -> (IEndpointRouteBuilder -> IEndpointRouteBuilder) -> 'state

    member this.get
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IEndpointRouteBuilder) ->
            r.MapGet(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.post
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IEndpointRouteBuilder) ->
            r.MapPost(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.put
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IEndpointRouteBuilder) ->
            r.MapPut(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.delete
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IEndpointRouteBuilder) ->
            r.MapDelete(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state


    //****************************************************************************************************
    // Basic Maps
    //****************************************************************************************************
    // MapGet
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Delegate, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: 'p -> 'r, ?config) =
        this.get s route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: 'p -> Task<'r>, ?config) =
        this.get s route (AsParameters.OfTask f) config

    // MapPost
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Delegate, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: 'p -> 'r, ?config) =
        this.post s route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: 'p -> Task<'r>, ?config) =
        this.post s route (AsParameters.OfTask f) config

    // MapPut
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Delegate, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: 'p -> 'r, ?config) =
        this.put s route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: 'p -> Task<'r>, ?config) =
        this.put s route (AsParameters.OfTask f) config

    // MapDelete
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Delegate, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: 'p -> 'r, ?config) =
        this.delete s route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: 'p -> Task<'r>, ?config) =
        this.delete s route (AsParameters.OfTask f) config


    //****************************************************************************************************
    // TypedResult Maps
    //****************************************************************************************************

    //----------------------------------------------------------------------------------------------------
    // MapGet

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> 't, ?config) =
        this.get state route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> Task<'t>, ?config) =
        this.get state route (AsParameters.OfTask f) config

    //----------------------------------------------------------------------------------------------------
    // MapPost

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> 't, ?config) =
        this.post state route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> Task<'t>, ?config) =
        this.post state route (AsParameters.OfTask f) config

    //----------------------------------------------------------------------------------------------------
    // MapPut

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> 't, ?config) =
        this.put state route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'p, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'p -> Task<'t>, ?config) =
        this.put state route (AsParameters.OfTask f) config

    //----------------------------------------------------------------------------------------------------
    // MapDelete
    // Get 1
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'a1 -> 't, ?config) =
        this.delete state route (AsParameters.Of f) config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: 'a1 -> Task<'t>, ?config) =
        this.delete state route (AsParameters.OfTask f) config
