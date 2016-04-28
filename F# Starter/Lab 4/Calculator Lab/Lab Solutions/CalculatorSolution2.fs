module Opsgility.Calculator

/// Adds two numbers together.
let add (x:int) (lastResult:int, history:string) : int * string =
    let result = lastResult + x
    result, history + (sprintf "Add %d and %d. " lastResult x)
/// Multiplies two numbers together.
let times x (lastResult, history) =
    let result = lastResult * x
    result, history + (sprintf "Times %d by %d. " lastResult x)
/// Subtracts one number from another.
let subtract x (lastResult, history) =
    let result = lastResult - x
    result, history + (sprintf "Subtract %d and %d. " lastResult x)
/// Divides one number by another. Only works for whole numbers!
let divideBy x (lastResult, history) =
    let result = lastResult / x
    result, history + (sprintf "Divide %d by %d. " lastResult x)
/// Doubles a number.
let double = times 2
/// Halves a number.
let halve = divideBy 2
/// Adds five to a number and then doubles it.
let addFiveAndDouble = add 5 >> double
