namespace FSharp.MinimalApi.Swagger

open System.Collections.Generic
open System.Text.Json.Serialization
open Microsoft.FSharp.Reflection
open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Models
open Swashbuckle.AspNetCore.SwaggerGen
open System.Linq

type ClearDocumentFilter() =
    interface IDocumentFilter with
        member this.Apply(swaggerDoc, context) =

            let schemas = swaggerDoc.Components.Schemas.ToList()

            for entry in schemas do
                if entry.Value.Pattern = "$remove" then
                    swaggerDoc.Components.Schemas.Remove(entry.Key) |> ignore

                    for s in context.SchemaRepository.Schemas do
                        for p in s.Value.Properties do
                            if p.Value.Reference <> null && p.Value.Reference.Id = entry.Key then
                                p.Value.Reference <- entry.Value.Reference
                                p.Value.Title <- entry.Value.Title
                                p.Value.Description <- entry.Value.Description
                                p.Value.Nullable <- entry.Value.Nullable
                                p.Value.Type <- entry.Value.Type
                                p.Value.Format <- entry.Value.Format
                                p.Value.Example <- entry.Value.Example

type OptionSchemaFilter() =
    interface ISchemaFilter with
        member this.Apply(schema, context) =
            let tp = context.Type

            if tp = typeof<string> then
                schema.Nullable <- false

            if tp.IsGenericType && tp.GetGenericTypeDefinition() = typedefof<Option<_>> then
                let argumentType = tp.GetGenericArguments()[0]
                let argumentSchema = SwaggerUtils.getSchema context argumentType

                schema.Title <- argumentSchema.Title
                schema.Nullable <- true
                schema.Type <- argumentSchema.Type
                schema.Example <- argumentSchema.Example
                schema.Format <- argumentSchema.Format
                schema.Properties <- argumentSchema.Properties
                schema.Items <- argumentSchema.Items
                schema.Pattern <- "$remove"

                if
                    not (SwaggerUtils.isPrimitive argumentType)
                    && not (context.SchemaRepository.Schemas.ContainsKey argumentType.Name)
                then
                    context.SchemaRepository.AddDefinition(argumentType.Name, argumentSchema)
                    |> ignore

type DicriminatedUnionSchemaFilter(options: JsonFSharpOptions) =
    let toIgnore = [ typedefof<_ option>; typedefof<_ list>; typedefof<Result<_, _>> ]

    interface ISchemaFilter with

        member this.Apply(schema, context) =
            let tp = context.Type

            if
                FSharpType.IsUnion tp |> not
                || (tp.IsGenericType && toIgnore.Contains(tp.GetGenericTypeDefinition()))
            then
                ()
            else

                let unionCases = FSharpType.GetUnionCases tp

                if unionCases.Length = 1 then
                    let unionCase = unionCases |> Array.exactlyOne

                    match unionCase.GetFields() with
                    | [| field |] ->
                        let underType = field.PropertyType

                        let argumentSchema = SwaggerUtils.getSchema context underType
                        schema.Pattern <- "$remove"
                        schema.Title <- tp.Name
                        schema.Reference <- argumentSchema.Reference
                        schema.Type <- argumentSchema.Type
                        schema.Example <- argumentSchema.Example
                        schema.Format <- argumentSchema.Format
                        schema.Properties <- argumentSchema.Properties
                        schema.Items <- argumentSchema.Items

                        if
                            not (SwaggerUtils.isPrimitive underType)
                            && not (context.SchemaRepository.Schemas.ContainsKey underType.Name)
                        then
                            context.SchemaRepository.AddDefinition(underType.Name, argumentSchema) |> ignore
                    | _ -> ()

                elif unionCases |> Array.forall (fun c -> c.GetFields().Length = 0) then
                    schema.Properties.Clear()
                    schema.Enum.Clear()
                    schema.Type <- "string"
                    schema.Format <- ""

                    for case in unionCases do
                        schema.Enum.Add(OpenApiString(case.Name))
                else
                    schema.Properties.Clear()
                    schema.Enum.Clear()
                    schema.OneOf.Clear()
                    schema.AllOf.Clear()
                    schema.AnyOf.Clear()

                    let tagName = options.UnionTagName
                    let fieldsName = options.UnionFieldsName

                    schema.Type <- "object"
                    let discriminator = OpenApiDiscriminator(PropertyName = tagName)
                    schema.Discriminator <- discriminator

                    for case in unionCases do
                        let schemaFields = OpenApiSchema(Type = "object", Required = HashSet [ tagName ])

                        let caseField =
                            OpenApiSchema(
                                Type = "string",
                                Enum = ResizeArray([ OpenApiString(case.Name) :> IOpenApiAny ])
                            )

                        schemaFields.Properties.Add(tagName, caseField)

                        match case.GetFields() |> List.ofArray with
                        | [] -> ()
                        | [ field ] ->
                            let schema = SwaggerUtils.getSchema context field.PropertyType
                            schemaFields.Properties.Add(fieldsName, schema)
                            discriminator.Mapping.Add(case.Name, field.PropertyType.Name)
                        | fields ->

                            let valueSchema = OpenApiSchema(Type = "object")

                            for field in fields do
                                let schema = SwaggerUtils.getSchema context field.PropertyType
                                valueSchema.Properties.Add(field.Name, schema)

                            let name = $"{tp.Name}.{case.Name}"
                            schemaFields.Properties.Add(fieldsName, valueSchema)
                            context.SchemaRepository.AddDefinition(name, valueSchema) |> ignore
                            discriminator.Mapping.Add(case.Name, name)

                        schema.OneOf.Add(schemaFields)
