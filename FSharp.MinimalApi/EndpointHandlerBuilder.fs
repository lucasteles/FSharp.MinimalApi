namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http

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
    member this.MapGet(s, route, f: Func<_, _>, ?config) =
        this.get s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config
    // MapPost
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _>, ?config) =
        this.post s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    // MapPut
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _>, ?config) =
        this.put s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    // MapDelete
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _>, ?config) =
        this.delete s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config


    //****************************************************************************************************
    // TypedResult Maps
    //****************************************************************************************************

    //----------------------------------------------------------------------------------------------------
    // MapGet

    // Get 1
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 't>, ?config) =
        this.get state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, Task<'t>>, ?config) =
        this.get state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 'a2, 't>, ?config) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, Task<'t>>,
            ?config
        ) =
        this.get state route f config


    // Get 3
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 4
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 5
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, Task<'t>>,
            ?config
        ) =
        this.get state route f config
    // Get 6
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, Task<'t>>,
            ?config
        ) =
        this.get state route f config
    // Get 7
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, Task<'t>>,
            ?config
        ) =
        this.get state route f config
    // Get 8
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, Task<'t>>,
            ?config
        ) =
        this.get state route f config
    // Get 9
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 10
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 11
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 12
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 13
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 14
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 15
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    // Get 16
    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't>,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(HttpMethodName.Get)>]
    member this.MapGet<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, Task<'t>>,
            ?config
        ) =
        this.get state route f config

    //----------------------------------------------------------------------------------------------------
    // MapPost

    // Get 1
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 't>, ?config) =
        this.post state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, Task<'t>>, ?config) =
        this.post state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 'a2, 't>, ?config) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, Task<'t>>,
            ?config
        ) =
        this.post state route f config


    // Get 3
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 4
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 5
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, Task<'t>>,
            ?config
        ) =
        this.post state route f config
    // Get 6
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, Task<'t>>,
            ?config
        ) =
        this.post state route f config
    // Get 7
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, Task<'t>>,
            ?config
        ) =
        this.post state route f config
    // Get 8
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, Task<'t>>,
            ?config
        ) =
        this.post state route f config
    // Get 9
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 10
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 11
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 12
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 13
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 14
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 15
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    // Get 16
    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't>,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(HttpMethodName.Post)>]
    member this.MapPost<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, Task<'t>>,
            ?config
        ) =
        this.post state route f config

    //----------------------------------------------------------------------------------------------------
    // MapPut

    // Get 1
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 't>, ?config) =
        this.put state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, Task<'t>>, ?config) =
        this.put state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 'a2, 't>, ?config) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, Task<'t>>,
            ?config
        ) =
        this.put state route f config


    // Get 3
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 4
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 5
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, Task<'t>>,
            ?config
        ) =
        this.put state route f config
    // Get 6
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, Task<'t>>,
            ?config
        ) =
        this.put state route f config
    // Get 7
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, Task<'t>>,
            ?config
        ) =
        this.put state route f config
    // Get 8
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, Task<'t>>,
            ?config
        ) =
        this.put state route f config
    // Get 9
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 10
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 11
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 12
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 13
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 14
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 15
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    // Get 16
    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't>,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(HttpMethodName.Put)>]
    member this.MapPut<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, Task<'t>>,
            ?config
        ) =
        this.put state route f config

    //----------------------------------------------------------------------------------------------------
    // MapDelete
    // Get 1
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, 't>, ?config) =
        this.delete state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 't when 't :> IResult>(state, route, _: unit -> 't, f: Func<'a1, Task<'t>>, ?config) =
        this.delete state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, Task<'t>>,
            ?config
        ) =
        this.delete state route f config


    // Get 3
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 4
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 5
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, Task<'t>>,
            ?config
        ) =
        this.delete state route f config
    // Get 6
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, Task<'t>>,
            ?config
        ) =
        this.delete state route f config
    // Get 7
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, Task<'t>>,
            ?config
        ) =
        this.delete state route f config
    // Get 8
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, Task<'t>>,
            ?config
        ) =
        this.delete state route f config
    // Get 9
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 10
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 11
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 12
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 13
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 't when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 14
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 15
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, Task<'t>>,
            ?config
        ) =
        this.delete state route f config

    // Get 16
    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't>,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(HttpMethodName.Delete)>]
    member this.MapDelete<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, 't
        when 't :> IResult>
        (
            state,
            route,
            _: unit -> 't,
            f: Func<'a1, 'a2, 'a3, 'a4, 'a5, 'a6, 'a7, 'a8, 'a9, 'a10, 'a11, 'a12, 'a13, 'a14, 'a15, 'a16, Task<'t>>,
            ?config
        ) =
        this.delete state route f config
