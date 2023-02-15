[<AutoOpen>]
module FSharp.MinimalApi.DI

open Microsoft.Extensions.DependencyInjection

type IServiceCollection with

    member services.AddTuples() =
        services
            .AddTransient(typedefof<_ * _>)
            .AddTransient(typedefof<_ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _ * _ * _ * _ * _>)
            .AddTransient(typedefof<_ * _ * _ * _ * _ * _ * _ * _ * _ * _>)
