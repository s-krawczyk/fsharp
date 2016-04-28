namespace Monopoly

type Position = 
    | Property of Name : string
    | Station of Name : string
    | Utility of Type : string
    | Chance of Id : int // a way of uniquely identifying the different Chance positions on the board
    | CommunityChest of Id : int 
    | Tax of Type : string
    | GoToJail
    | Go
    | FreeParking
    | Jail

type Outcome = 
    | Pay of int
    | Earn of int
    | Bankrupt
