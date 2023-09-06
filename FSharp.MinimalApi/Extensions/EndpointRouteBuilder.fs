[<AutoOpen>]
module FSharp.MinimalApi.EndpointRouteBuilder

open System.Diagnostics.CodeAnalysis
open Delegate
open Microsoft.AspNetCore.Routing
open System
open FSharp.Core
open Microsoft.AspNetCore.Builder

[<Literal>]
let private route = "Route"

type IEndpointRouteBuilder with

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _>) =
        builder.MapGet(pattern, fromFuncWithMaybeUnit handler)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapGet
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapGet(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _>) =
        builder.MapPost(pattern, fromFuncWithMaybeUnit handler)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPost
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPost(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _>) =
        builder.MapPut(pattern, fromFuncWithMaybeUnit handler)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapPut
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapPut(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _>) =
        builder.MapDelete(pattern, fromFuncWithMaybeUnit handler)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete([<StringSyntax(route)>] pattern: string, handler: Func<_, _, _, _, _, _, _, _, _, _, _>) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)

    member builder.MapDelete
        (
            [<StringSyntax(route)>] pattern: string,
            handler: Func<_, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _, _>
        ) =
        builder.MapDelete(pattern, handler :> Delegate)
