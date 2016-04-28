module Monopoly.Controller

open System

/// Given a dice e.g. (1,4) and current board position, gets the new position.
let calculateNextMove dice currentPosition = 
    // Get the total of the dice
    let diceValue = fst dice + snd dice

    // Try to get the current index of the board (tryGetIndex returns "int option")
    let currentIndex = Data.Board |> List.tryFindIndex (fun position -> position = currentPosition)

    // Get the new position. If current index is None, then return a default of "Go".
    match currentIndex with
    | Some currentIndex ->
        let newIndex = currentIndex + diceValue
        Data.Board.[newIndex % Data.Board.Length]
    | None -> Go

let private roll =
    let roller = Random()
    fun () -> roller.Next(1, 7)
let rollDice() = roll(), roll()

let calculateOutcome position = 
    match position with
    | Property "Euston Road" | Station "Marylebone Road" -> Some(Earn 150)
    | Property _ -> Some(Pay 100)
    | Jail -> Some Bankrupt
    | Go -> Some(Earn 500)
    | FreeParking -> Some(Earn 250)
    | _ -> None

let updatePlayerEarnings outcome player = 
    match outcome with
    | None -> player
    | Some(Pay amount) -> { player with Money = player.Money - amount }
    | Some(Earn amount) -> { player with Money = player.Money + amount }
    | Some Bankrupt -> { player with Money = 0 }

let updatePlayerPosition newPosition player = { player with Position = newPosition }

let move dice player =
    let newPosition = calculateNextMove dice player.Position
    let outcome = calculateOutcome newPosition

    player
    |> updatePlayerEarnings outcome
    |> updatePlayerPosition newPosition
