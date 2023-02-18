namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open FSharp.Core
open Microsoft.AspNetCore.Routing
open Microsoft.AspNetCore.Builder

type App = WebApplication
type IRoute = IEndpointRouteBuilder
type Identity<'t> = 't -> 't

module Delegate =
    let inline fromFuncWithMaybeUnit (func: Func<'a, 'b>) : Delegate =
        match box func with
        | :? Func<unit, 'b> as f -> Func<'b>((f |> unbox<Func<unit, 'b>>).Invoke) :> Delegate
        | _ -> func :> Delegate

module Task =
    let ignore tsk =
        task {
            let! _ = tsk
            return ()
        }
        :> Task

[<AutoOpen>]
module Utils =
    let inline implicit (x: ^a) : ^b =
        ((^a or ^b): (static member op_Implicit: ^a -> ^b) x)

    let inline (!>) v = implicit v

module internal Func =
    let tap f arg =
        f arg |> ignore
        arg
