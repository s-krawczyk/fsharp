module WebDemo.Program

open Microsoft.Owin.Hosting
open System
open System.Net.Http

[<EntryPoint>]
let main _ = 
    use webapp = WebApp.Start<Startup>("http://localhost:9000/")
    Console.ReadLine() |> ignore
    0
























//    let response =
//        let client = new HttpClient()
//        client.GetAsync(baseAddress + "api/values").Result
//    printfn "%O" response
//    printfn "%s" (response.Content.ReadAsStringAsync().Result)
