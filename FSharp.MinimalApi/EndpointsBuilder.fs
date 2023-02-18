namespace FSharp.MinimalApi

open System
open System.Diagnostics
open System.Threading.Tasks
open Microsoft.AspNetCore.Authorization
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing

type EndpointsMap =
    internal
        { Timestamp: int64
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
            MapFn = state.MapFn >> Func.tap f }

    member _.Zero() =
        { Timestamp = 0
          MapFn = id
          GroupName = groupName }

    member _.Run(route: EndpointsMap) = route

    member this.Yield(()) = this.Zero()

    member this.Yield(route: EndpointsMap) =
        { route with
            Timestamp = Stopwatch.GetTimestamp() }

    member _.Delay(f) = f ()

    member this.Combine(endpoints1: EndpointsMap, endpoints2: EndpointsMap) =
        let maps = [ endpoints1; endpoints2 ] |> List.sortBy (fun e -> e.Timestamp)

        match maps[0], maps[1] with
        | { GroupName = None }, { GroupName = Some _ }
        | { GroupName = Some _ }, { GroupName = None } as (m1, m2) ->
            { m1 with
                MapFn = m1.MapFn >> Func.tap m2.Apply }

        | { GroupName = None }, { GroupName = None }
        | { GroupName = Some _ }, { GroupName = Some _ } as (m1, m2) ->
            if m1.Timestamp = 0 then
                { m1 with
                    MapFn = m1.MapFn >> (Func.tap m2.Apply) }
            else
                { MapFn = (Func.tap m1.Apply) >> (Func.tap m2.Apply)
                  Timestamp = min m1.Timestamp m2.Timestamp
                  GroupName = None }

    member this.For(state: EndpointsMap, f: unit -> EndpointsMap) = this.Combine(state, f ())

    [<CustomOperation("group")>]
    member _.Group(state, name) = { state with GroupName = Some name }

    [<CustomOperation("use_routes")>]
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
            MapFn = state.MapFn << Func.tap f }

    [<CustomOperation("allow_anonymous")>]
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

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization()) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: string[]) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: IAuthorizeData[]) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, policy: AuthorizationPolicy) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(policy)) }

    [<CustomOperation("add_filter")>]
    member _.AddFilter<'f when 'f :> IEndpointFilter>(state) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.AddEndpointFilter<'f>()) }

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

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, builder: AuthorizationPolicyBuilder -> unit) =
        { state with
            MapFn = state.MapFn >> (fun e -> e.RequireAuthorization(builder)) }
