open System
open System.IO

// Set the current directory for script execution to the directory of the file (rather than the Temp dir)
Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

// Load our data access code.
#load "DataAccess.fsx"

// Code in an fsx file resides by default in a module equal to the filename
open DataAccess

// Exercise 1 - Load in data from a flat file into memory
let data : Result list =
    File.ReadLines "FootballResults.csv"
    |> Seq.skip 1
    |> Seq.choose parseRow
    |> Seq.toList

// Exercise 2 - What the result between Tottenham and Arsenal?
data
|> List.find(fun res -> res.``Home Team`` = "Tottenham" && res.``Away Team`` = "Arsenal")

// Exercise 3 - What match had the most goals?
data
|> List.sortByDescending(fun row -> row.``Full Time Home Goals`` + row.``Full Time Away Goals``)
|> List.head

// Exercise 4 - Which team has won away from home the most?
// 4.1 - What is an away win?
let isAwayWin (res:Result) = res.``Full Time Away Goals`` > res.``Full Time Home Goals``

// 4.2 - Filter all results by away wins, group by the away team, count the number of matches and then sort downwards based on that count
data
|> List.filter isAwayWin
|> List.countBy (fun res -> res.``Away Team``)
|> List.sortByDescending snd

// Exercise 5 - who is the dirtiest team (yellow cards = 1 point, red cards = 3 points)
data
|> List.collect(fun row ->
    [ row.``Home Team``, row.``Home Yellow Cards``, row.``Home Red Cards``
      row.``Away Team``, row.``Away Yellow Cards``, row.``Away Red Cards`` ])
|> List.groupBy(fun (team, _, _) -> team)
|> List.map(fun (team, cards) ->
    team,
    cards |> List.sumBy(fun (_, yellows, reds) -> yellows + (reds * 3)))
|> List.sortByDescending snd

