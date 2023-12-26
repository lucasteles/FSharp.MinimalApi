[<AutoOpen>]
module FSharp.MinimalApi.Builder.Builders

let inline private implicit (x: ^a) : ^b =
    ((^a or ^b): (static member op_Implicit: ^a -> ^b) x)

let inline (!!) v = implicit v

let endpoints = EndpointsBuilder()
let withGroup groupName = EndpointsBuilder groupName
