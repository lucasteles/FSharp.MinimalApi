namespace FSharp.MinimalApi

open System
open System.Threading.Tasks
open FSharp.MinimalApi.RoutingConfiguration
open Microsoft.AspNetCore.Http

module internal LazyConfiguration =
    let applyConfiguration (app: App) (ConfigurationSteps actions)  =
       for f in actions |> List.rev do f app |> ignore
       actions

type AppConfigurationBuilder() =
    let wrap (ConfigurationSteps steps) (step: App -> App) =
            step::steps |> ConfigurationSteps
        
    member _.Yield _: ConfigurationSteps  = ConfigurationSteps []
 
    [<CustomOperation("applyTo")>]
    member _.Apply(steps: ConfigurationSteps, app: App) =  
        LazyConfiguration.applyConfiguration app steps |> ignore
       
    [<CustomOperation("useConfiguration")>]
    member _.UseConfiguration(ConfigurationSteps actions, [<ParamArray>]otherSteps: ConfigurationSteps[]): ConfigurationSteps =
        (otherSteps |> List.ofArray |> List.map (fun (ConfigurationSteps s) -> s) |> List.concat ) @ actions |> ConfigurationSteps
        
    // MapGet 
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_>, ?config) = Get.mapRouteHandleUnit route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: HttpContext -> Task, ?config) = Get.mapRouteReq route f config |> wrap steps 
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config |> wrap steps
    [<CustomOperation(mapGetOp)>] member _.MapGet(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) = Get.mapRoute route f config|> wrap steps
    
    // MapPost
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: HttpContext -> Task, ?config) =  Post.mapRouteReq route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_>, ?config) =  Post.mapRouteHandleUnit route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPostOp)>] member this.MapPost(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Post.mapRoute route f config |> wrap steps
    
    
    // MapPut
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: HttpContext -> Task, ?config) =  Put.mapRouteReq route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_>, ?config) =  Put.mapRouteHandleUnit route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    [<CustomOperation(mapPutOp)>] member this.MapPut(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Put.mapRoute route f config |> wrap steps
    
    
    // MapDelete
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: HttpContext -> Task, ?config) =  Delete.mapRouteReq route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_>, ?config) =  Delete.mapRouteHandleUnit route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    [<CustomOperation(mapDeleteOp)>] member this.MapDelete(steps, route, f: Func<_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_>, ?config) =  Delete.mapRoute route f config |> wrap steps
    