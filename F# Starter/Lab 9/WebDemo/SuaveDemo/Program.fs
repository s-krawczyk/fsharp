open Suave
open Suave.Http.Successful
open Suave.Web
open Suave.Http
open Suave.Http.Applicatives
open System
open Newtonsoft.Json
open Suave.Types

type Person = { Name : string; Age : int }

type HousePriceResult =
    { Price : int
      DateOfTransfer : DateTime
      Street : string
      TownCity : string
      PostCode : string }

let findHouseSales (town, minPrice, maxPrice) =
    async {
        //TODO: Correct this code as the AsyncExecute signature changes!
        let! results = DataAccess.FindByTownPrice.Create().AsyncExecute()
        return
            //TODO: Map from the type returned by the DAL to the DTO
            //that will be exposed by Suave.
            results
            |> Seq.map(fun result ->
                { Price = 1
                  DateOfTransfer = DateTime.MinValue
                  Street = "STREET"
                  TownCity = "TOWNCITY"
                  PostCode = "PCODE" })
            |> Seq.toArray }

let handleRoute =
    choose [
        path "/" >>= (OK "Hello World!")
        path "/values" >>=
            choose [
                GET >>= ([1; 2; 3 ] |> JSON)
                POST >>=
                    fun ctx -> async {
                        printfn "GOT A POST!"
                        return Some ctx }
            ]
        pathScan "/values/%d" (fun id -> OK (sprintf "Details: %d" id))
        pathScan "/human/%s/%d" (fun (name, age) -> { Name = name; Age = age } |> JSON)
        pathScan "/housePrice/%s/%d/%d" (findHouseSales >> JSONAsync)
    ]

[<EntryPoint>]
let main argv = 
    startWebServer defaultConfig handleRoute
    printfn "%A" argv
    0 // return an integer exit code

















