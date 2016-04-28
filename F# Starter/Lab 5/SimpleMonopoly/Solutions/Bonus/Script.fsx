#load @"Scripts\load-project.fsx"

open Monopoly

// Create a mutable player
let mutable mutablePlayer = { Name = "Isaac"; Position = Go; Money = 1500 }

// Play 50 times
for i = 1 to 50 do
    printf "Currently player is %A. " mutablePlayer
    let dice = Controller.rollDice()
    // update mutable player with result of call to Controller.move
    mutablePlayer <- (mutablePlayer |> Controller.move dice)
    printfn "Rolled %A." dice
