namespace BasicApi.Models

open System

type UserId = UserId of Guid

[<CLIMutable>]
type User =
    { Id: UserId
      Name: string
      Email: string }

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
type NewUser =
    { Name: string
      Email: string }

    static member validate(info: NewUser) =
        let problems =
            [ nameof info.Email,
              [| if String.IsNullOrWhiteSpace info.Email then
                     "Empty email"

                 if not <| info.Email.Contains "@" then
                     "Invalid email" |]

              nameof info.Name,
              [| if String.IsNullOrWhiteSpace info.Name then
                     "Empty name"
                 if info.Name.Length < 3 then
                     "Short name" |] ]

        problems
        |> List.filter (fun (_, errs) -> errs.Length > 0)
        |> function
            | [] -> Ok()
            | errors -> errors |> dict |> Error
