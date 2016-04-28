#load @"Scripts\load-project.fsx"

open Monopoly

// Exercise 1 - experiment and explore this code
Controller.calculateNextMove (1, 3) (Property "Mayfair")




// Exercise 2 test cases
//Controller.move (1,3) Go // Tax "Income Tax", None
//Controller.move (4,2) (Property "Euston Road") // Property "Northumberland Avenue", Some (Pay 100)
//Controller.move (1,1) (Property "Whitehall") // Station "Marylebone Road", None
//Controller.move (2,3) (Station "Kings Cross") // Jail, Some Bankrupt




// Exercise 3 test cases
//let player = { Name = "Isaac"; Position = Go; Money = 1500 }
//
//// Test #1
//player
//|> Controller.move (6,2) // {Name = "Isaac"; Position = Property "Euston Road"; Money = 1650;}
//
//// Test #2
//player
//|> Controller.move (6,2)
//|> Controller.move (3,5)
//|> Controller.move (3,1) // {Name = "Isaac"; Position = FreeParking; Money = 1800;}
//
//// Test #3
//player
//|> Controller.move (6,2)
//|> Controller.move (1,1)
//|> Controller.move (3,2)
//|> Controller.move (2,1) // {Name = "Isaac"; Position = Property "Marlborough Street"; Money = 50;}
//
