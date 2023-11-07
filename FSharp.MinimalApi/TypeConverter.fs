module TypeConverter

open System
open FSharp.MinimalApi
open System.ComponentModel
open System.Reflection
open Microsoft.FSharp.Reflection

type SingleUnionTypeConverter<'u>() =
    inherit TypeConverter()

    let backingConverter =
        let case = FSharpType.GetUnionCases(typeof<'u>) |> Array.tryExactlyOne

        case
        |> Option.map (fun c -> c.GetFields())
        |> Option.bind Array.tryExactlyOne
        |> Option.map (fun f -> TypeDescriptor.GetConverter f.PropertyType)
        |> Option.zip case

    override this.CanConvertFrom(context, sourceType) =
        backingConverter
        |> Option.exists (fun (_, c) -> c.CanConvertFrom(context, sourceType))

    override this.CanConvertTo(context, destType) =
        backingConverter
        |> Option.exists (fun (_, c) -> c.CanConvertTo(context, destType))

    override this.ConvertFrom(context, culture, value) =
        match backingConverter with
        | None -> null
        | Some(u, c) -> FSharpValue.MakeUnion(u, [| c.ConvertFrom(context, culture, value) |])

    override this.ConvertTo(context, culture, value, destinationType) =
        match backingConverter with
        | None -> null
        | Some(u, c) ->
            let value = FSharpValue.GetUnionFields(value, u.DeclaringType) |> snd |> Array.head
            c.ConvertTo(context, culture, value, destinationType)

type SimpleUnionTypeConverter<'u>() =
    inherit TypeConverter()

    let cases =
        FSharpType.GetUnionCases(typeof<'u>)
        |> Array.filter (fun c -> c.GetFields() |> Array.isEmpty)

    let isValid = cases |> (not << Array.isEmpty)

    override this.CanConvertFrom(context, sourceType) = isValid && sourceType = typeof<string>

    override this.CanConvertTo(context, destinationType) =
        isValid && destinationType = typeof<string>

    override this.ConvertFrom(context, culture, value) =
        cases
        |> Array.tryFind (fun c -> c.Name = string value)
        |> Option.map (fun c -> FSharpValue.MakeUnion(c, [||]))
        |> Option.toObj

    override this.ConvertTo(context, culture, value, destinationType) =
        cases
        |> Array.tryFind value.Equals
        |> Option.map (fun c -> box c.Name)
        |> Option.toObj

let addUnionCase t =
    let cases = FSharpType.GetUnionCases(t)

    if cases |> Array.forall (fun c -> c.GetFields().Length = 0) then
        let converter = typedefof<SimpleUnionTypeConverter<_>>.MakeGenericType(t)
        TypeDescriptor.AddAttributes(t, TypeConverterAttribute(converter)) |> ignore

    if cases.Length = 1 then
        let converter = typedefof<SingleUnionTypeConverter<_>>.MakeGenericType(t)
        TypeDescriptor.AddAttributes(t, TypeConverterAttribute(converter)) |> ignore

let registerUnionTypesInAssembly (assembly: Assembly) =
    assembly.GetTypes()
    |> Array.filter FSharpType.IsUnion
    |> Array.iter addUnionCase

let registerUnionTypesInAssemblyContaining<'t> =
    typeof<'t>.Assembly |> registerUnionTypesInAssembly

[<Obsolete>]
let registerUnionTypes<'t> = registerUnionTypesInAssemblyContaining<'t>
