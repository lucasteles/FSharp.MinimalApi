namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Authorization
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing

type EndpointMap =
    internal
        { MapFn: Identity<IRoute> }

    member this.Apply(r: IRoute) = this.MapFn r

type EndpointGroup =
    { GroupBuilderFn: Identity<RouteGroupBuilder>
      EndpointsMapFn: Identity<IRoute>
      RootMapFn: Identity<IRoute>
      GroupName: string }

    member this.Apply(r: IRoute) =
        let group = r.MapGroup(this.GroupName)
        let route = this.GroupBuilderFn group :> IRoute

        route |> this.RootMapFn |> ignore
        route |> this.EndpointsMapFn |> ignore
        r

type EndpointsBuilder() =
    inherit RouterBaseBuilder<EndpointMap>()

    override this.Append state f = { state with MapFn = state.MapFn << f }
    member _.Run(route: EndpointMap) = route
    member _.Zero() = { MapFn = id }
    member this.Yield(_: unit) = this.Zero()
    member this.Yield(v) = v

    member _.Delay(f) = f ()

    member this.Combine(s1: EndpointMap, s2: EndpointMap) = this.Append s1 s2.MapFn
    member this.Combine(endpoint: EndpointMap, group: EndpointGroup) = this.Append endpoint group.Apply
    member this.Combine(group: EndpointGroup, endpoint: EndpointMap) = this.Combine(endpoint, group)

    [<CustomOperation("set")>]
    member this.Set(state, f) = this.Append state (Func.tap f)

    member this.Combine(group1: EndpointGroup, group2: EndpointGroup) =
        (group1.Apply >> group2.Apply) |> this.Append(this.Zero())

    member this.For(state: EndpointMap, f: unit -> EndpointMap) = this.Combine(state, f ())
    member this.For(state: EndpointMap, f: unit -> EndpointGroup) = this.Combine(state, f ())

type GroupBuilder(groupName: string) =
    inherit RouterBaseBuilder<EndpointGroup>()

    override this.Append state f =
        { state with
            EndpointsMapFn = state.EndpointsMapFn << f }

    member _.Zero() =
        { EndpointsMapFn = id
          GroupBuilderFn = id
          RootMapFn = id
          GroupName = groupName }

    member _.Run(route: EndpointGroup) = route
    member this.Yield(()) = this.Zero()
    member this.Yield(v) = v
    member _.Delay(f) = f ()

    member this.Combine(s1: EndpointGroup, s2: EndpointGroup) =
        match s1.GroupName = groupName, s2.GroupName = groupName with
        | false, false -> invalidOp "Invalid group name"
        | true, false ->
            { s1 with
                EndpointsMapFn = s1.EndpointsMapFn << s2.Apply
                GroupBuilderFn = s1.GroupBuilderFn << s2.GroupBuilderFn }
        | false, true ->
            { s2 with
                EndpointsMapFn = s2.EndpointsMapFn << s1.Apply
                GroupBuilderFn = s2.GroupBuilderFn << s1.GroupBuilderFn }

        | true, true ->
            { s1 with
                EndpointsMapFn = s1.EndpointsMapFn << s2.EndpointsMapFn
                RootMapFn = s2.RootMapFn << s1.RootMapFn
                GroupBuilderFn = s1.GroupBuilderFn << s2.GroupBuilderFn }

    member this.Combine(group: EndpointGroup, endpoint: EndpointMap) =
        { group with
            RootMapFn = group.RootMapFn << endpoint.MapFn }

    member this.Combine(s1: EndpointMap, s2: EndpointGroup) = this.Combine(s2, s1)

    member this.For(state: EndpointGroup, f: unit -> EndpointGroup) = this.Combine(state, f ())
    member this.For(state: EndpointGroup, f: unit -> EndpointMap) = this.Combine(state, f ())
    member this.For(state: EndpointMap, f: unit -> EndpointGroup) = this.Combine(f (), state)

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
