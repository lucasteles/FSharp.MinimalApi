namespace FSharp.MinimalApi.Builder

open System
open System.Diagnostics
open System.Threading.Tasks
open Microsoft.AspNetCore.Authorization
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing
open FSharp.MinimalApi

type EndpointsMap =
    internal
        { Order: int64
          MapFn: RouteGroupBuilder -> RouteGroupBuilder
          GroupName: string option }

    member this.Apply(r: IEndpointRouteBuilder) =
        this.GroupName |> Option.defaultValue String.Empty |> r.MapGroup |> this.MapFn

type EndpointsBuilder(?groupName: string) =
    inherit RouterBaseBuilder<EndpointsMap>()

    let trimPath (path: string) = path.Trim('/')
    let concatPath (paths: string seq) = String.concat "/" paths

    override this.Append state f =
        { state with
            MapFn = state.MapFn >> tap f }

    member _.Zero() =
        { Order = 0
          MapFn = id
          GroupName = groupName }

    member _.Run(route: EndpointsMap) = route
    member _.Run(()) = ()

    member this.Yield(()) = this.Zero()

    member this.Yield(route: EndpointsMap) =
        { route with
            Order = Stopwatch.GetTimestamp() }

    member _.Delay(f) = f ()

    member this.Combine(endpoints1: EndpointsMap, endpoints2: EndpointsMap) =
        let maps = [ endpoints1; endpoints2 ] |> List.sortBy (fun e -> e.Order)

        match maps[0], maps[1] with
        | { GroupName = None }, { GroupName = Some _ }
        | { GroupName = Some _ }, { GroupName = None } as (m1, m2) ->
            { m1 with
                MapFn = m1.MapFn >> tap m2.Apply }

        | { GroupName = None }, { GroupName = None }
        | { GroupName = Some _ }, { GroupName = Some _ } as (m1, m2) ->
            if m1.Order = 0 then
                { m1 with
                    MapFn = m1.MapFn >> (tap m2.Apply) }
            else
                { MapFn = (tap m1.Apply) >> (tap m2.Apply)
                  Order = 1
                  GroupName = None }

    member this.For(state: EndpointsMap, f: unit -> EndpointsMap) = this.Combine(state, f ())

    [<CustomOperation("group")>]
    member _.Group(state, name) = { state with GroupName = Some name }

    [<CustomOperation("useRoutes")>]
    member _.useRoutes(state, endpoints) =
        { state with
            MapFn = state.MapFn >> endpoints.MapFn }

    [<CustomOperation("path")>]
    member _.Path(state, [<ParamArray>] segments: string[]) =
        { state with
            GroupName = segments |> Array.map trimPath |> concatPath |> Some }

    [<CustomOperation("set")>]
    member _.Set(state, f) =
        { state with
            MapFn = state.MapFn << tap f }

    [<CustomOperation("allowAnonymous")>]
    member _.AllowAnonymous(state) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.AllowAnonymous()) }

    [<CustomOperation("tags")>]
    member _.Tags(state, [<ParamArray>] tags) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.WithTags(tags)) }

    [<CustomOperation("description")>]
    member _.Description(state, desc) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.WithDescription(desc)) }

    [<CustomOperation("requireAuthorization")>]
    member _.RequireAuth(state) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization()) }

    [<CustomOperation("requireAuthorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: string[]) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("requireAuthorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: IAuthorizeData[]) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("requireAuthorization")>]
    member _.RequireAuth(state, policy: AuthorizationPolicy) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policy)) }

    [<CustomOperation("filter")>]
    member _.Filter<'args, 'f when 'f :> IEndpointFilter>(state, ctor: 'args -> 'f) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.AddEndpointFilter<'f>()) }

    [<CustomOperation("filter")>]
    member _.Filter<'f when 'f :> IEndpointFilter>(state, filter: 'f) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.AddEndpointFilter(filter)) }

    [<CustomOperation("filter")>]
    member _.Filter
        (
            state,
            f: EndpointFilterInvocationContext -> (EndpointFilterInvocationContext -> ValueTask<obj>) -> ValueTask<obj>
        ) =
        let filter =
            { new IEndpointFilter with
                member _.InvokeAsync(ctx, next) = f ctx next.Invoke }

        { state with
            MapFn = state.MapFn >> (fun e -> e.AddEndpointFilter(filter)) }

    [<CustomOperation("filter")>]
    member _.Filter
        (
            state,
            f: EndpointFilterInvocationContext -> (EndpointFilterInvocationContext -> ValueTask<obj>) -> Task<obj>
        ) =
        let filter =
            { new IEndpointFilter with
                member _.InvokeAsync(ctx, next) = ValueTask<obj>(f ctx next.Invoke) }

        { state with
            MapFn = state.MapFn >> (fun e -> e.AddEndpointFilter(filter)) }

    [<CustomOperation("requireAuthorization")>]
    member _.RequireAuth(state, builder: AuthorizationPolicyBuilder -> unit) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(builder)) }

    [<CustomOperation("apply")>]
    member this.Apply(state: EndpointsMap, app) =
        let mapper = this.Run state
        mapper.Apply app |> ignore
