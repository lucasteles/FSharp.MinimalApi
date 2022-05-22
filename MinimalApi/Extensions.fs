module [<AutoOpen>] FSharp.MinimalApi.Extensions 

open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System
open FSharp.MinimalApi
open FSharp.MinimalApi.RoutingConfiguration

type WebApplication with
 
    [<CustomOperation("useConfiguration")>]
    member app.UseConfiguration(_, [<ParamArray>]otherSteps: ConfigurationSteps[]) =
        for config in otherSteps do
           LazyConfiguration.applyConfiguration app config |> ignore
        app
        
    member app.UseConfiguration(configurationSteps) =
       LazyConfiguration.applyConfiguration app configurationSteps |> ignore
       app
        
    member this.Yield _ = ()
    member _.Run(_) = ()
    
    // MapGet
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: HttpContext -> Task, ?config) = this |> Get.mapRouteReq route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_>, ?config) = this |> Get.mapRouteHandleUnit route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    [<CustomOperation(mapGetOp)>] member this.MapGet(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Get.mapRoute route f config |> ignore
    
    // MapPost
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: HttpContext -> Task, ?config) = this |> Post.mapRouteReq route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_>, ?config) = this |> Post.mapRouteHandleUnit route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    [<CustomOperation(mapPostOp)>] member this.MapPost(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Post.mapRoute route f config |> ignore
    
    
    // MapPut
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: HttpContext -> Task, ?config) = this |> Put.mapRouteReq route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_>, ?config) = this |> Put.mapRouteHandleUnit route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    [<CustomOperation(mapPutOp)>] member this.MapPut(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Put.mapRoute route f config |> ignore
    
    
    // MapDelete
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: HttpContext -> Task, ?config) = this |> Delete.mapRouteReq route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_>, ?config) = this |> Delete.mapRouteHandleUnit route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(_, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = this |> Delete.mapRoute route f config |> ignore
    
