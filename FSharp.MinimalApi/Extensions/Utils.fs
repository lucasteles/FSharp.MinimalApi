namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open FSharp.Core

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
    let inline private implicit (x: ^a) : ^b =
        ((^a or ^b): (static member op_Implicit: ^a -> ^b) x)

    let inline (!>) v = implicit v

module internal Func =
    let tap f arg =
        f arg |> ignore
        arg

module internal Option =
    let zip a b =
        match a, b with
        | Some a, Some b -> Some(a, b)
        | _ -> None
