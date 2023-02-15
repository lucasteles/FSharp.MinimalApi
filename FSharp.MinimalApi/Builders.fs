[<AutoOpen>]
module FSharp.MinimalApi.Builders

let endpoints = EndpointsBuilder()
let group name = GroupBuilder name
let section = group ""
