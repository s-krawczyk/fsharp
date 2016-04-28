// Hello, World in an F# script.
// open the System namespace
open System

/// Prints "Hello, World {name}" to the Console.
let printHello(name:string) : unit =
    Console.WriteLine("Hello, World {0}", name)

/// Prints "Hello, World {name}" to the Console using printfn.
let printHelloTwo(name:string) : unit =
    printfn "Hello, World %s from printfn" name

// You can then call the function as below.
printHello("isaac")
printHelloTwo("isaac")
