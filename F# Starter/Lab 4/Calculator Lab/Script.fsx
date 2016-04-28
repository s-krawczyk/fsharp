#load "Calculator.fs"


(* Start by filling in the following functions.
   Add has been done for you. Fill in the implementation
   for the others! *)

/// Adds two numbers together.
let add x y = y + x
/// Multiplies two numbers together.
let times x y = 0

// watch out for ordering on these functions...
/// Subtracts one number from another.
let subtract x y = 0
/// Divides one number by another. Only works for whole numbers!
let divideBy x y = 0

// see if you can reuse the functions defined above here
/// Doubles a number.
let double = 0
/// Halves a number.
let halve = 0

// compose "add" and "double" here using the >> operator (and remove the explicit "number" argument)
/// Adds five to a number and then doubles it.
let addFiveAndDouble number = 0

// test out your code with these samples: -
let simpleAdd = add 5 10 // should = 15
let simplePipeline = add 5 0 |> times 3 |> subtract 5 |> divideBy 2 |> addFiveAndDouble // should = 20
let orderingTest = 19 |> subtract 3 |> divideBy 2 // should = 8