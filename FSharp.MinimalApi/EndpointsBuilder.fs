namespace FSharp.MinimalApi

open System
open System.IO
open System.Threading.Tasks
open Microsoft.AspNetCore.Authorization
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing

type EndpointsMap =
    { GroupBuilderFn: Identity<RouteGroupBuilder>
      RootMapFn: Identity<IRoute>
      MapFn: Identity<IRoute>
      GroupName: string option }

    member this.Apply(r: IRoute) =
        let group = this.GroupName |> Option.defaultValue String.Empty |> r.MapGroup
        let route = this.GroupBuilderFn group :> IRoute

        route |> this.RootMapFn |> ignore
        route |> this.MapFn |> ignore
        r

type EndpointsBuilder() =
    inherit RouterBaseBuilder<EndpointsMap>()

    override this.Append state f = { state with MapFn = state.MapFn << f }

    member _.Zero() =
        { MapFn = id
          GroupBuilderFn = id
          RootMapFn = id
          GroupName = None }

    member _.Run(route: EndpointsMap) = route
    member this.Yield(()) = this.Zero()
    member this.Yield(v) = v
    member _.Delay(f) = f ()

    member this.Combine(s1: EndpointsMap, s2: EndpointsMap) =
        match s1.GroupName, s2.GroupName with
        | Some _, None ->
            { s1 with
                RootMapFn = s1.RootMapFn << s2.Apply
                GroupBuilderFn = s1.GroupBuilderFn << s2.GroupBuilderFn }
        | None, Some _ ->
            { s2 with
                RootMapFn = s2.RootMapFn << s1.Apply
                GroupBuilderFn = s2.GroupBuilderFn << s1.GroupBuilderFn }

        | None, None ->
            { s1 with
                MapFn = s1.MapFn << s2.MapFn
                RootMapFn = s2.RootMapFn << s1.RootMapFn
                GroupBuilderFn = s1.GroupBuilderFn << s2.GroupBuilderFn }

        | Some group1, Some group2 ->
            { s1 with
                MapFn = s1.MapFn << s2.MapFn
                RootMapFn = s2.RootMapFn << s1.RootMapFn
                GroupBuilderFn = s1.GroupBuilderFn << s2.GroupBuilderFn
                GroupName = Path.Combine(group1, group2) |> Some }

    member this.For(state: EndpointsMap, f: unit -> EndpointsMap) = this.Combine(state, f ())

    [<CustomOperation("group")>]
    member _.Group(state, name) = { state with GroupName = Some name }

    [<CustomOperation("path")>]
    member _.Path(state, [<ParamArray>] segments: string[]) =
        { state with
            GroupName =
                segments
                |> Array.fold (fun path seg -> Path.Combine(path, seg)) String.Empty
                |> Some }

    [<CustomOperation("set")>]
    member _.Set(state, f) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn << Func.tap f }

    [<CustomOperation("allow_anonymous")>]
    member _.AllowAnonymous(state) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.AllowAnonymous()) }

    [<CustomOperation("tags")>]
    member _.Tags(state, [<ParamArray>] tags) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.WithTags(tags)) }

    [<CustomOperation("description")>]
    member _.Description(state, desc) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.WithDescription(desc)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.RequireAuthorization()) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: string[]) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, [<ParamArray>] policies: IAuthorizeData[]) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.RequireAuthorization(policies)) }

    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, policy: AuthorizationPolicy) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.RequireAuthorization(policy)) }

    [<CustomOperation("add_filter")>]
    member _.AddFilter<'f when 'f :> IEndpointFilter>(state) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.AddEndpointFilter<'f>()) }

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
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.AddEndpointFilter(filter)) }

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
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.AddEndpointFilter(filter)) }


    [<CustomOperation("require_authorization")>]
    member _.RequireAuth(state, builder: AuthorizationPolicyBuilder -> unit) =
        { state with
            GroupBuilderFn = state.GroupBuilderFn >> (fun e -> e.RequireAuthorization(builder)) }
