namespace FSharp.MinimalApi.Swagger

open System
open System.Linq
open System.Collections.Generic
open System.Globalization
open System.Text.RegularExpressions
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc.ApiExplorer
open Swashbuckle.AspNetCore.SwaggerGen

module internal SwaggerUtils =
    let getSchema (context: SchemaFilterContext) (t: Type) =
        match context.SchemaRepository.Schemas.TryGetValue(t.Name) with
        | true, sch -> sch
        | _ -> context.SchemaGenerator.GenerateSchema(t, context.SchemaRepository)

    let isPrimitive (t: Type) =
        t.IsPrimitive || t = typeof<Guid> || t = typeof<string> || t = typeof<decimal>

module internal HashCode =
    open Microsoft.FSharp.Core.Operators

    let stable (str: string) =
        let mutable hash1 = 5381
        let mutable hash2 = hash1

        let mutable i = 0

        while i < str.Length && str[i] <> '\000' do
            hash1 <- ((hash1 <<< 5) + hash1) ^^^ (int str[i])

            if i = str.Length - 1 || str[i + 1] = '\000' then
                ()
            else
                hash2 <- ((hash2 <<< 5) + hash2) ^^^ (int str[i + 1])

            i <- i + 2

        hash1 + hash2 * 1566083941 |> uint32

module SwaggerFSharpHelper =
    let autoTagActions (api: ApiDescription) =

        [| match
               api.ActionDescriptor.EndpointMetadata.OfType<TagsAttribute>()
               |> Seq.collect (fun t -> t.Tags)
               |> List.ofSeq
           with
           | [] ->
               api.RelativePath.Split('/', StringSplitOptions.RemoveEmptyEntries)
               |> Seq.map CultureInfo.InvariantCulture.TextInfo.ToTitleCase
               |> Seq.tryFind (fun p -> p.ToLower() <> "api")
               |> Option.defaultValue "api"
           | values -> yield! values |]
        : IList<string>

    let rec schemaIdSelector (tp: Type) =
        if not tp.IsGenericType then
            Regex.Replace(tp.Name, "dto$", "DTO", RegexOptions.IgnoreCase)
        else
            let typeParam =
                tp.GetGenericArguments() |> Array.map schemaIdSelector |> String.concat ","

            let name = tp.GetGenericTypeDefinition().Name.Split('`')[0]

            if name.Contains "<>f__AnonymousType" then
                let props = tp.GetProperties()

                let defName =
                    if props.Length = 0 then
                        tp.Name
                    elif props.Length = 1 then
                        props[0].Name
                    else
                        $"{{{String.Join(',', props.Select(fun x -> x.Name))}}}"

                $"{defName}_{HashCode.stable tp.FullName}"

            elif name.StartsWith("FSharpOption") then
                $"{typeParam}?"
            elif name.StartsWith("IEnumerable") || name.StartsWith("FSharpList") then
                $"{typeParam}[]"
            else
                $"{name}<{typeParam}>"
