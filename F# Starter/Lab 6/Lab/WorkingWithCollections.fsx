open System
open System.IO

// Set the current directory for script execution to the directory of the file (rather than the Temp dir)
Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

// Load our data access code.
#load "DataAccess.fsx"

// Code in an fsx file resides by default in a module equal to the filename
open DataAccess

// Exercise 1 - Load in data from a flat file into memory
let data : Result list = [] // load from "FootballResults.csv"

// Exercise 2 - What the result between Tottenham and Arsenal?

// Exercise 3 - What match had the most goals?

// Exercise 4 - Which team has won away from home the most?
// 4.1 - What is an away win?
// 4.2 - Filter all results by away wins, group by the away team, count the number of matches and then sort downwards based on that count

// Exercise 5 - who is the dirtiest team (yellow cards = 1 point, red cards = 3 points)
