[<AutoOpen>]
module FSharp.MinimalApi.Builders

let endpoints = EndpointsBuilder()
let mapGroup groupName = EndpointsBuilder groupName
