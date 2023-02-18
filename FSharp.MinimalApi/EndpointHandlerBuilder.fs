namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open Constants
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http

[<AbstractClass>]
type RouterBaseBuilder<'state>() =
    abstract Append: 'state -> Identity<IRoute> -> 'state

    member this.get
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IRoute) ->
            printfn $"{route}"
            r.MapGet(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.post
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IRoute) ->
            r.MapPost(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.put
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IRoute) ->
            r.MapPut(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state

    member this.delete
        (state: 'state)
        (route: string)
        (f: Delegate)
        (config: (RouteHandlerBuilder -> RouteHandlerBuilder) option)
        =
        fun (r: IRoute) ->
            r.MapDelete(route, f) |> Option.defaultValue id config |> ignore
            r
        |> this.Append state


    //****************************************************************************************************
    // Basic Maps
    //****************************************************************************************************
    // MapGet
    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _>, ?config) =
        this.get s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config

    [<CustomOperation(mapGetOp)>]
    member this.MapGet(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.get s route f config
    // MapPost
    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _>, ?config) =
        this.post s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    [<CustomOperation(mapPostOp)>]
    member this.MapPost(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.post s route f config

    // MapPut
    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _>, ?config) =
        this.put s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    [<CustomOperation(mapPutOp)>]
    member this.MapPut(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.put s route f config

    // MapDelete
    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _>, ?config) =
        this.delete s route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _>, ?config) = this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config

    [<CustomOperation(mapDeleteOp)>]
    member this.MapDelete(s, route, f: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>, ?config) =
        this.delete s route f config


    //****************************************************************************************************
    // TypedResult Maps
    //****************************************************************************************************

    //----------------------------------------------------------------------------------------------------
    // MapGet

    // Get 1
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^t when ^t :> IResult>(state, route, _: unit -> ^t, f: Func< ^a1, ^t >, ?config) =
        this.get state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, Task< ^t > >,
            ?config
        ) =
        this.get state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, Task< ^t > >,
            ?config
        ) =
        this.get state route f config


    // Get 3
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 4
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 5
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, Task< ^t > >,
            ?config
        ) =
        this.get state route f config
    // Get 6
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, Task< ^t > >,
            ?config
        ) =
        this.get state route f config
    // Get 7
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, Task< ^t > >,
            ?config
        ) =
        this.get state route f config
    // Get 8
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, Task< ^t > >,
            ?config
        ) =
        this.get state route f config
    // Get 9
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 10
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 11
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 12
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 13
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 14
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 15
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    // Get 16
    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t >,
            ?config
        ) =
        this.get state route f config


    [<CustomOperation(mapGetOp)>]
    member inline this.MapGet< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, Task< ^t > >,
            ?config
        ) =
        this.get state route f config

    //----------------------------------------------------------------------------------------------------
    // MapPost

    // Get 1
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^t when ^t :> IResult>(state, route, _: unit -> ^t, f: Func< ^a1, ^t >, ?config) =
        this.post state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, Task< ^t > >,
            ?config
        ) =
        this.post state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, Task< ^t > >,
            ?config
        ) =
        this.post state route f config


    // Get 3
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 4
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 5
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, Task< ^t > >,
            ?config
        ) =
        this.post state route f config
    // Get 6
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, Task< ^t > >,
            ?config
        ) =
        this.post state route f config
    // Get 7
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, Task< ^t > >,
            ?config
        ) =
        this.post state route f config
    // Get 8
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, Task< ^t > >,
            ?config
        ) =
        this.post state route f config
    // Get 9
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 10
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 11
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 12
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 13
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 14
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 15
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    // Get 16
    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t >,
            ?config
        ) =
        this.post state route f config


    [<CustomOperation(mapPostOp)>]
    member inline this.MapPost< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, Task< ^t > >,
            ?config
        ) =
        this.post state route f config

    //----------------------------------------------------------------------------------------------------
    // MapPut

    // Get 1
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^t when ^t :> IResult>(state, route, _: unit -> ^t, f: Func< ^a1, ^t >, ?config) =
        this.put state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, Task< ^t > >,
            ?config
        ) =
        this.put state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, Task< ^t > >,
            ?config
        ) =
        this.put state route f config


    // Get 3
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 4
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 5
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, Task< ^t > >,
            ?config
        ) =
        this.put state route f config
    // Get 6
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, Task< ^t > >,
            ?config
        ) =
        this.put state route f config
    // Get 7
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, Task< ^t > >,
            ?config
        ) =
        this.put state route f config
    // Get 8
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, Task< ^t > >,
            ?config
        ) =
        this.put state route f config
    // Get 9
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 10
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 11
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 12
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 13
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 14
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 15
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    // Get 16
    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t >,
            ?config
        ) =
        this.put state route f config


    [<CustomOperation(mapPutOp)>]
    member inline this.MapPut< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, Task< ^t > >,
            ?config
        ) =
        this.put state route f config

    //----------------------------------------------------------------------------------------------------
    // MapDelete
    // Get 1
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^t >,
            ?config
        ) =
        this.delete state route (Delegate.fromFuncWithMaybeUnit f) config

    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, Task< ^t > >,
            ?config
        ) =
        this.delete state route (Delegate.fromFuncWithMaybeUnit f) config

    // Get 2
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config


    // Get 3
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 4
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 5
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config
    // Get 6
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config
    // Get 7
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config
    // Get 8
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config
    // Get 9
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 10
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 11
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 12
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^t when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 13
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 14
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 15
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config

    // Get 16
    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t >,
            ?config
        ) =
        this.delete state route f config


    [<CustomOperation(mapDeleteOp)>]
    member inline this.MapDelete< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, ^t
        when ^t :> IResult>
        (
            state,
            route,
            _: unit -> ^t,
            f: Func< ^a1, ^a2, ^a3, ^a4, ^a5, ^a6, ^a7, ^a8, ^a9, ^a10, ^a11, ^a12, ^a13, ^a14, ^a15, ^a16, Task< ^t > >,
            ?config
        ) =
        this.delete state route f config
