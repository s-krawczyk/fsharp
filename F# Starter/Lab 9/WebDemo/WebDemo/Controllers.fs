namespace WebDemo

open System.Web.Http
open System

type ValuesController(name:string) =
    inherit ApiController()
    member __.Get() = [ "value1"; "value2" ]
    member __.Get(id: int) = sprintf "value %d" id
    
    member __.Post([<FromBody>]value : string) =
        printfn "Received a post %s" value
    
    member __.Put(id:int, [<FromBody>]value:string) =
        printfn "Received a put %d %s" id value
    
    member __.Delete(id) = printfn "Received a DELETE %d" id
        

open System.Net
open System.Threading

type Person = { Name : string; Age : int }
type Creature = Person of Person | Cat of furColour : string

type CreatureController() =
    inherit ApiController()
    member __.Get() = { Name = "Isaac"; Age = 35 }
    member __.Get(id) =
        if id % 2 = 0 then Person { Name = "Someone"; Age = id }
        else Cat "Black"

    [<Route("api/creature/weather/{id}")>]
    member __.Get(id:string) =
        let uri = Uri("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + id + "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys")
        use wc = new WebClient()
        printfn "About to start downloading on thread %d" Thread.CurrentThread.ManagedThreadId
        let asyncWork =
            async {
                printfn "Inside async block on thread %d" Thread.CurrentThread.ManagedThreadId
                let! data = wc.DownloadStringTaskAsync(uri) |> Async.AwaitTask
                printfn "Resumed on thread %d" Thread.CurrentThread.ManagedThreadId
                printfn "Downloaded data: %s" data
                return data.Length
            }
        
        asyncWork |> Async.StartAsTask



















