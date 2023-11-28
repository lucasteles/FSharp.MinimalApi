namespace FSharp.MinimalApi.Builder

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Http.HttpResults

[<AutoOpen>]
type ProducesHook =
    static member produces<'t when 't :> IResult>(()) = Unchecked.defaultof<'t>

    static member produces<'t1, 't2 when 't1 :> IResult and 't2 :> IResult>(()) = Unchecked.defaultof<Results<'t1, 't2>>

    static member produces<'t1, 't2, 't3 when 't1 :> IResult and 't2 :> IResult and 't3 :> IResult>(()) =
        Unchecked.defaultof<Results<'t1, 't2, 't3>>

    static member produces<'t1, 't2, 't3, 't4
        when 't1 :> IResult and 't2 :> IResult and 't3 :> IResult and 't4 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4>>

    static member produces<'t1, 't2, 't3, 't4, 't5
        when 't1 :> IResult and 't2 :> IResult and 't3 :> IResult and 't4 :> IResult and 't5 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, 't6>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6, 't7
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult
        and 't7 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, Results<'t6, 't7>>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6, 't7, 't8
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult
        and 't7 :> IResult
        and 't8 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, Results<'t6, 't7, 't8>>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6, 't7, 't8, 't9
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult
        and 't7 :> IResult
        and 't8 :> IResult
        and 't9 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, Results<'t6, 't7, 't8, 't9>>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6, 't7, 't8, 't9, 't10
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult
        and 't7 :> IResult
        and 't8 :> IResult
        and 't9 :> IResult
        and 't10 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, Results<'t6, 't7, 't8, 't9, 't10>>>

    static member produces<'t1, 't2, 't3, 't4, 't5, 't6, 't7, 't8, 't9, 't10, 't11
        when 't1 :> IResult
        and 't2 :> IResult
        and 't3 :> IResult
        and 't4 :> IResult
        and 't5 :> IResult
        and 't6 :> IResult
        and 't7 :> IResult
        and 't8 :> IResult
        and 't9 :> IResult
        and 't10 :> IResult
        and 't11 :> IResult>
        (())
        =
        Unchecked.defaultof<Results<'t1, 't2, 't3, 't4, 't5, Results<'t6, 't7, 't8, 't9, 't10, 't11>>>
