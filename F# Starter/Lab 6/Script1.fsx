let numbers = [ 1 .. 20 ]

numbers.[0]

numbers |> List.tryItem 0
numbers |> List.tryFind ((=) 20)

match numbers with
| [] -> "empty list"
| [ single ] -> sprintf "Single item: %d" single
| [ first; second ] -> sprintf "Two items: %d %d" first second
| head :: tail -> sprintf "Head of %d and tail of %A" head tail

let head :: tail = numbers |> List.take 3



























// 1. ResizeArray and LINQ
// 2. Lists - immutability. add item to head. append to list.
// 3. Arrays - mutability, standard .NET.
// 4. Combinators - toList, toArray, ofSeq etc.
// 5. Sets
// 6. Maps and Dictionaries

// part 2

//let numbers = [ 1 .. 20 ]

// Getting at items safely
// numbers.[0] // unsafe
// numbers |> List.tryItem // safe
//match [ 1; 2 ] with // safe
//| [] -> "empty list"
//| [ single ] -> sprintf "Single item: %d" single
//| [ first; second ] -> sprintf "Two items: %d %d" first second
//| head :: tail -> sprintf "Head of %d and tail of %A" head tail
//

//type Sex = | Male | Female
//type Customer = { CustomerId : int; Name : string; Sex : Sex }
//
//let customerIds = [ 0 .. 20 ]
//
//let getCustomer cId =
//    match cId with
//    | 1 | 3 -> Some { CustomerId = cId; Name = "Fred Smith"; Sex = Male }
//    | 6 | 12 -> Some { CustomerId = cId; Name = "Tara Thomas"; Sex = Female }
//    | _ -> None

// groupBy, countBy
// pairwise, windowed
// partition

//#load @"Scripts\load-project.fsx"
//
//open Monopoly
//
//// Create a mutable player
//let mutablePlayer = { Name = "Isaac"; Position = Go; Money = 1500 }
//
//// Play 50 times
////for i = 1 to 50 do
////    printf "Currently player is %A. " mutablePlayer
////    let dice = Controller.rollDice()
////    mutablePlayer <- (mutablePlayer |> Controller.move dice)
////    printfn "Rolled %A." dice
//
//let finalState =
//    (mutablePlayer, [ 1 .. 50 ])
//    ||> List.fold (fun playerState iteration ->
//        printf "Currently player is %A. " playerState
//        let dice = Controller.rollDice()
//        printfn "Rolled %A." dice
//        Controller.move dice playerState)
