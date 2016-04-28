module Monopoly.Controller

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