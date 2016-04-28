// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

/// Prints "Hello, World {name}" to the Console using printfn.
let printHello(name:string) : unit =
    printfn "Hello, World %s" name

[<EntryPoint>]
let main argv = 
    printHello argv.[0]
    0 // return an integer exit code
    