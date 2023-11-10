[<AutoOpen>]
module FSharp.MinimalApi.Swagger.Extensions

open Microsoft.Extensions.DependencyInjection
open Microsoft.OpenApi.Models
open Swashbuckle.AspNetCore.SwaggerGen
open System

type SwaggerGenOptions with

    member options.ConfigureFSharp() =
        options.CustomSchemaIds SwaggerFSharpHelper.schemaIdSelector
        options.SchemaFilter<OptionSchemaFilter>()
        options.SchemaFilter<DicriminatedUnionSchemaFilter>()
        options.DocumentFilter<ClearDocumentFilter>()
        options.MapType<DateOnly>(fun () -> OpenApiSchema(Type = "string", Format = "date"))
        options.MapType<TimeOnly>(fun () -> OpenApiSchema(Type = "string", Format = "time"))
        options.TagActionsBy SwaggerFSharpHelper.autoTagActions
