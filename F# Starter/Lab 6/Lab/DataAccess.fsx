open System

type Result = {
    Date : DateTime
    ``Home Team`` : string
    ``Away Team`` : string
    ``Full Time Home Goals`` : int
    ``Full Time Away Goals`` : int
    ``Half Time Home Goals`` : int
    ``Half Time Away Goals`` : int
    ``Home Shots`` : int
    ``Away Shots`` : int
    ``Home Shots on Target`` : int
    ``Away Shots on Target`` : int
    ``Home Fouls`` : int
    ``Away Fouls`` : int
    ``Home Yellow Cards`` : int
    ``Away Yellow Cards`` : int
    ``Home Red Cards`` : int
    ``Away Red Cards`` : int }

let parseRow (row:string) =
    try
    let fields = row.Split ','
    { Date = DateTime.ParseExact(fields.[0], "MM/dd/yyyy", null)
      ``Home Team`` = fields.[1]
      ``Away Team`` = fields.[2]
      ``Full Time Home Goals`` = int fields.[3]
      ``Full Time Away Goals`` = int fields.[4]
      ``Half Time Home Goals`` = int fields.[6]
      ``Half Time Away Goals`` = int fields.[7]
      ``Home Shots`` = int fields.[9]
      ``Away Shots`` = int fields.[10]
      ``Home Shots on Target`` = int fields.[11]
      ``Away Shots on Target`` = int fields.[12]
      ``Home Fouls`` = int fields.[13]
      ``Away Fouls`` = int fields.[14]
      ``Home Yellow Cards`` = int fields.[17]
      ``Away Yellow Cards`` = int fields.[18]
      ``Home Red Cards`` = int fields.[19]
      ``Away Red Cards`` = int fields.[20] } |> Some
    with ex ->
        printfn "Oops! Error reading row '%s!'" row
        printfn "Encountered exception: %O" ex
        None