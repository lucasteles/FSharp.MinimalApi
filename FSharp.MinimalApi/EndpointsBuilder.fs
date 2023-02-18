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
        { Index: int64
          RootMapFn: RouteGroupBuilder -> RouteGroupBuilder
          GroupName: string option }

    member this.Apply(r: IEndpointRouteBuilder) =
        this.GroupName
        |> Option.defaultValue String.Empty
        |> r.MapGroup
        |> this.RootMapFn

type EndpointsBuilder(?groupName: string) =
    inherit RouterBaseBuilder<EndpointsMap>()

    let trimPath (path: string) = path.Trim('/')
    let concatPath (paths: string seq) = String.concat "/" paths

    override this.Append state f =
        { state with
            RootMapFn = state.RootMapFn >> Func.tap f }

    member _.Zero() =
        { Index = 0
          RootMapFn = id
          GroupName = groupName }

    member _.Run(route: EndpointsMap) =
        { route with
            Index = Stopwatch.GetTimestamp() }

    member this.Yield(()) = this.Zero()
    member this.Yield(v) = v
    member _.Delay(f) = f ()

    member this.Combine(endpoints1: EndpointsMap, endpoints2: EndpointsMap) =
        let maps = [ endpoints1; endpoints2 ] |> List.sortBy (fun e -> e.Index)

        match maps[0], maps[1] with
        | { GroupName = None }, { GroupName = Some _ }
        | { GroupName = Some _ }, { GroupName = None } as (m1, m2) ->
            { m1 with
                RootMapFn = m1.RootMapFn >> Func.tap m2.Apply }

        | { GroupName = Some group1 }, { GroupName = Some group2 } as (m1, m2) when trimPath group1 = trimPath group2 ->
            { m1 with
                RootMapFn = m1.RootMapFn >> m2.RootMapFn
                Index = min m1.Index m2.Index }

        | { GroupName = None }, { GroupName = None } as (m1, m2) ->
            { m1 with
                RootMapFn = m1.RootMapFn >> m2.RootMapFn }

        | { GroupName = Some _ }, { GroupName = Some _ } as (m1, m2) ->
            { m1 with
                RootMapFn = m1.RootMapFn >> Func.tap m2.Apply }

    member this.For(state: EndpointsMap, f: unit -> EndpointsMap) = this.Combine(state, f ())

    [<CustomOperation("group")>]
    member _.Group(state, name) = { state with GroupName = Some name }

    [<CustomOperation("path")>]
    member _.Path(state, [<ParamArray>] segments: string[]) =
        { state with
            GroupName = segments |> Array.map trimPath |> concatPath |> Some }

    [<CustomOperation("set")>]
    member _.Set(state, f) =
        { state with
            RootMapFn = state.RootMapFn << Func.tap f }

    [<CustomOperation("allow_anonymous")>]
    member _.AllowAnonymous(state) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.AllowAnonymous()) }

    [<CustomOperation("tags")>]
    member _.Tags(state, [<ParamArray>] tags) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.WithTags(tags)) }

    [<CustomOperation("description")>]
    member _.Description(state, desc) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.WithDescription(desc)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.RequireAuthorization()) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: string[]) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: IAuthorizeData[]) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, policy: AuthorizationPolicy) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.RequireAuthorization(policy)) }

    [<CustomOperation("add_filter")>]
    member _.AddFilter<'f when 'f :> IEndpointFilter>(state) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.AddEndpointFilter<'f>()) }

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
            RootMapFn = state.RootMapFn >> (fun e -> e.AddEndpointFilter(filter)) }

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
            RootMapFn = state.RootMapFn >> (fun e -> e.AddEndpointFilter(filter)) }


    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, builder: AuthorizationPolicyBuilder -> unit) =
        { state with
            RootMapFn = state.RootMapFn >> (fun e -> e.RequireAuthorization(builder)) }
