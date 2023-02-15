[<AutoOpen>]
module BasicApi.Extensions

open System
open System.Linq
open System.Threading
open System.Threading.Tasks
open Microsoft.EntityFrameworkCore

module Option =
    let from (v: 'T) =
        if Object.ReferenceEquals(v, null) then None else Some v

type IQueryable<'T> with

    member this.TryFirstAsync() =
        task {
            let! r = this.FirstOrDefaultAsync()
            return Option.from r
        }

    member this.TryFirstAsync pred =
        task {
            let! r = this.FirstOrDefaultAsync(pred, CancellationToken.None)
            return Option.from r
        }


type DbSet<'T when 'T: not struct> with

    member this.add v = this.Add(v) |> ignore
    member this.remove v = this.Remove(v) |> ignore

type DbContext with

    member this.saveChangesAsync v =
        task {
            let! _ = this.SaveChangesAsync()
            return ()
        }
        :> Task
