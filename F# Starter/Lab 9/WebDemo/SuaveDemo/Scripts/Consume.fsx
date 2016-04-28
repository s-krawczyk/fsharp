#load "load-project.fsx"

open HttpClient
open Newtonsoft.Json
open Program

let postRequest =
    createRequest Post "http://localhost:8083/"
    |> withBody "test"
    |> withHeader (ContentType "application/json")

let tryGetBody<'a> =
    createRequest Get
    >> getResponse
    >> fun response -> response.EntityBody
    >> Option.map(fun body -> JsonConvert.DeserializeObject<'a> body)

let sara = tryGetBody<Person> "http://localhost:8083/human/sara/28"