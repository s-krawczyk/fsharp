module Opsgility.Calculator

/// Represents the result and history of a calculation.
type Result = { Answer : int; History : ResizeArray<string> }
/// An initial empty state, used to begin calculation pipelines.
let InitialState = { Answer = 0; History = ResizeArray() }

/// Adds two numbers together.
let add (x:int) (state:Result) : Result =
    let newAnswer = state.Answer + x
    let newHistory = ResizeArray(state.History.AsReadOnly())
    newHistory.Add(sprintf "Add %d and %d" state.Answer x)
    { Answer = newAnswer; History = newHistory }
/// Multiplies two numbers together.
let times x state =
    let newAnswer = state.Answer * x
    let newHistory = ResizeArray(state.History.AsReadOnly())
    newHistory.Add(sprintf "Add %d and %d" state.Answer x)
    { Answer = newAnswer; History = newHistory }
/// Subtracts one number from another.
let subtract x state =
    let newAnswer = state.Answer - x
    let newHistory = ResizeArray(state.History.AsReadOnly())
    newHistory.Add(sprintf "Add %d and %d" state.Answer x)
    { Answer = newAnswer; History = newHistory }
/// Divides one number by another. Only works for whole numbers!
let divideBy x state =
    let newAnswer = state.Answer / x
    let newHistory = ResizeArray(state.History.AsReadOnly())
    newHistory.Add(sprintf "Add %d and %d" state.Answer x)
    { Answer = newAnswer; History = newHistory }
/// Doubles a number.
let double = times 2
/// Halves a number.
let halve = divideBy 2
/// Adds five to a number and then doubles it.
let addFiveAndDouble = add 5 >> double
