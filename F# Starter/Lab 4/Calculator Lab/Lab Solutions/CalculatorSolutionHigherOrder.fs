module Opsgility.Calculator

/// Represents the result and history of a calculation.
type Result = { Answer : int; History : ResizeArray<string> }
/// An initial empty state, used to begin calculation pipelines.
let InitialState = { Answer = 0; History = ResizeArray() }

(* A higher order function. Takes in the calculation function,
   executes it, and updates the state whilst returning it with the result. *)
let private processCalculation calculation text value state =
    let newAnswer = calculation state.Answer value
    let newHistory =
        let history = ResizeArray(state.History.AsReadOnly())
        history.Add(sprintf "%s %d and %d" text state.Answer value)
        history
    { Answer = newAnswer; History = newHistory }

/// Adds two numbers together.
let add = processCalculation (fun x y -> y + x) "Add"
/// Multiplies two numbers together.
let times = processCalculation (fun x y -> y * x) "Times"
/// Subtracts one number from another.
let subtract = processCalculation (fun x y -> y - x) "Subtract"
/// Divides one number by another. Only works for whole numbers!
let divideBy = processCalculation (fun x y -> y / x) "Divide"
/// Doubles a number.
let double = times 2
/// Halves a number.
let halve = divideBy 2
/// Adds five to a number and then doubles it.
let addFiveAndDouble = add 5 >> double

