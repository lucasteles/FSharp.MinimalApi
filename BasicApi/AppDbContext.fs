module BasicApi.Db

open System
open BasicApi.Models
open Microsoft.EntityFrameworkCore

module private EntityConfig =
    let user (builder: ModelBuilder) =
        let user = builder.Entity<User>()
        user.HasKey(fun u -> u.Id :> obj) |> ignore

        user.Property(fun u -> u.Id).HasConversion((fun (UserId id) -> id), UserId)
        |> ignore

        user.HasData(
            { Id = Guid.NewGuid() |> UserId
              Name = "Ryu"
              Email = "ryu@capcom.com" }
        )
        |> ignore

    let blog (builder: ModelBuilder) =
        let blog = builder.Entity<Blog>()
        blog.HasKey(fun u -> u.Id :> obj) |> ignore

        blog.Property(fun u -> u.Id).HasConversion((fun (BlogId id) -> id), BlogId)
        |> ignore

        blog.HasOne<User>().WithMany().HasForeignKey(fun u -> u.OwnerId :> obj)
        |> ignore

    let post (builder: ModelBuilder) =
        let post = builder.Entity<BlogPost>()

        post
            .Property(fun u -> u.Id)
            .HasConversion((fun (BlogPostId id) -> id), BlogPostId)
        |> ignore

        post.HasOne<Blog>().WithMany().HasForeignKey(fun u -> u.BlogId :> obj) |> ignore
        post.HasKey(fun u -> u.Id :> obj) |> ignore

type AppDbContext(options) =
    inherit DbContext(options)
    member this.Users = this.Set<User>()
    member this.Posts = this.Set<BlogPost>()
    member this.Blogs = this.Set<Blog>()

    override this.OnModelCreating builder =
        [ EntityConfig.user; EntityConfig.post; EntityConfig.blog ]
        |> Seq.iter (fun f -> f builder)
