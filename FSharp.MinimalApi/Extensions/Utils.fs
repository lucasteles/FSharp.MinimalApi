namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open FSharp.Core

module Delegate =
    let inline fromFuncWithMaybeUnit (func: Func<'a, 'b>) : Delegate =
        match box func with
        | :? Func<unit, 'b> as f -> Func<'b>((f |> unbox<Func<unit, 'b>>).Invoke) :> Delegate
        | _ -> func :> Delegate

[<AutoOpen>]
module internal Utils =
    let tap f arg =
        f arg |> ignore
        arg

module internal Option =
    let zip a b =
        match a, b with
        | Some a, Some b -> Some(a, b)
        | _ -> None
