namespace BasicApi.Models

open System

type UnionValue =
    | ANumber of int
    | AString of string
    | Nothing

type UserId =
    | UserId of Guid

    member this.Value = let (UserId value) = this in value


type Email = Email of string

[<CLIMutable>]
type User =
    { Id: UserId
      Name: string
      Email: Email }

type BlogId = BlogId of Guid

[<CLIMutable>]
type Blog =
    { Id: BlogId
      Name: string
      Slug: string
      OwnerId: UserId }

type BlogPostId = BlogPostId of Guid

[<CLIMutable>]
type BlogPost =
    { Id: BlogPostId
      Name: string
      BlogId: BlogId }

[<CLIMutable>]
type NewUser = { Name: string; Email: string }

[<CLIMutable>]
type MyCustomSettings =
    { MagicNumber: int option
      Enabled: bool
      Email: Email }

module Email =
    let value (Email email) = email

    let create (emailStr: string) =
        let errors =
            [| if String.IsNullOrWhiteSpace emailStr then
                   "Empty email"

               if not <| emailStr.Contains "@" then
                   "Invalid email" |]

        if errors |> Array.isEmpty then
            emailStr.ToLower().Trim() |> Email |> Ok
        else
            errors |> Error

module NewUser =
    let parseUser (info: NewUser) =
        let problems =
            [ match Email.create info.Email with
              | Error errors -> nameof info.Email, errors
              | Ok e -> ()

              nameof info.Name,
              [| if String.IsNullOrWhiteSpace info.Name then
                     "Empty name"
                 if info.Name.Length < 3 then
                     "Short name" |] ]

        problems
        |> List.filter (fun (_, errs) -> errs.Length > 0)
        |> function
            | [] ->
                { Id = Guid.NewGuid() |> UserId
                  Name = info.Name
                  Email = Email info.Email }
                |> Ok
            | errors -> errors |> dict |> Error
