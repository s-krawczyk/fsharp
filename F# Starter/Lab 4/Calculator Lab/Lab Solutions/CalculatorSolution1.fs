module Opsgility.Calculator

/// Adds two numbers together.
let add x y = x + y
/// Multiplies two numbers together.
let times x y = x * y
/// Subtracts one number from another.
let subtract x y = y - x
/// Divides one number by another. Only works for whole numbers!
let divideBy x y = y / x
/// Doubles a number.
let double = times 2
/// Halves a number.
let halve = divideBy 2
/// Adds five to a number and then doubles it.
let addFiveAndDouble = add 5 >> double
