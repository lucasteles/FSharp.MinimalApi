[<AutoOpen>]
module FSharp.MinimalApi.Builders

let endpoints = EndpointsBuilder()
let withGroup groupName = EndpointsBuilder groupName
