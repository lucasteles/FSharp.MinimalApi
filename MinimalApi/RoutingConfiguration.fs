module internal FSharp.MinimalApi.RoutingConfiguration

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
let [<Literal>] mapGetOp = "mapGet"
let [<Literal>] mapPostOp = "mapPost"
let [<Literal>] mapPutOp = "mapPut"
let [<Literal>] mapDeleteOp = "mapDelete"

module Core =
    let inline mapRouteReq methodCall  route (f: HttpContext -> Task) config =
        fun (app: App) -> methodCall app route (RequestDelegate f) |> Option.defaultValue id config |> ignore; app
        
    let inline mapRoute methodCall  route (f: Delegate) config =
        fun (app: App) -> methodCall app route f |> Option.defaultValue id config |> ignore; app
        
    let inline mapRouteHandleUnit<'a, 'b> methodCall route (f: Func<'a, 'b>) config =
        if (typeof<'a> = typeof<unit>)
        then mapRoute methodCall route (Func<'b> (f |> box |> unbox<Func<unit, 'b>>).Invoke) config 
        else mapRoute methodCall route f config
        
module Methods =
    let get (app: App) route (f: Delegate) =  app.MapGet(route,f)
    let getReq (app: App) route (f: RequestDelegate) =  app.MapGet(route,f)
    
    let post (app: App) route (f: Delegate) =  app.MapPost(route,f)
    let postReq (app: App) route (f: RequestDelegate) =  app.MapPost(route,f)
    
    let put (app: App) route (f: Delegate) =  app.MapPut(route,f)
    let putReq (app: App) route (f: RequestDelegate) =  app.MapPut(route,f)
 
    let delete (app: App) route (f: Delegate) =  app.MapDelete(route,f)
    let deleteReq (app: App) route (f: RequestDelegate) =  app.MapDelete(route,f)
 
    
module Get =
    open Core
    let inline mapRouteReq route =  mapRouteReq Methods.getReq route
    let inline mapRouteHandleUnit route = mapRouteHandleUnit Methods.get route
    let inline mapRoute route =  mapRoute Methods.get route
    
module Post =
    open Core
    let inline mapRouteReq route =  mapRouteReq Methods.postReq route
    let inline mapRouteHandleUnit route = mapRouteHandleUnit Methods.post route
    let inline mapRoute route =  mapRoute Methods.post route
    
module Put =
    open Core
    let inline mapRouteReq route =  mapRouteReq Methods.putReq route
    let inline mapRouteHandleUnit route = mapRouteHandleUnit Methods.put route
    let inline mapRoute route =  mapRoute Methods.put route

module Delete =
    open Core
    let inline mapRouteReq route =  mapRouteReq Methods.deleteReq route
    let inline mapRouteHandleUnit route = mapRouteHandleUnit Methods.delete route
    let inline mapRoute route =  mapRoute Methods.delete route
