namespace UnitTesting

module BusinessLogic =
    let getName() = "Isaac"
    let likesFSharp name = [ "Isaac"; "Don"; "Tomas" ] |> Seq.contains name
    let likesFootball name = name = "Fred"
    let add x y = x + y

open FsUnit.Xunit
open Xunit
open BusinessLogic
open Swensen.Unquote

module Tests =

    [<Fact>]
    let ``GetName always returns Isaac``() =
        getName() |> should equal "Isaac"
    [<Fact>]
    let ``Given a calculator, when we add Five and Ten, then the answer should be Fifteen``() =
        add 5 10 |> should not' (be 14)
        add 5 10 |> should be (greaterThan 10)
        add 5 10 |> should equal 15
    
    [<Fact>]
    let ``add 99 and -1 = 98``() =
        test <@ (add 99 -1) + 10 * 4 / 2 = 99 @>

    open canopy
    open runner

    [<Fact>]
    let ``Sample Canopy Test``() =
        start firefox
        url "http://lefthandedgoat.github.io/canopy/testpages/"
        "#welcome" == "Welcome"




























//    [<Fact>]
//    let ``GetName always returns Isaac``() =
//        Assert.Equal("Isaac", getName())
//    [<Fact>]
//    let ``Given a calculator, when we add Five and Ten, then the answer should be Fifteen``() =
//        Assert.Equal(15, add 5 10)

//open FsUnit.Xunit
//    [<Fact>]
//    let GetName_always_returns_isaac() =
//        getName() |> should equal "Isaac"
//    [<Fact>]
//    let GivenACalculatorWhenWeAddFiveAndTenThenTheAnswerShouldBeFifteen() =
//        add 5 10 |> should not' (be 14)
//        add 5 10 |> should be (greaterThan 10)
//        add 5 10 |> should equal 15

// binding redirects!

//open canopy
//open runner
//    [<Fact>]
//    let fsharporg_is_awesome() =
//        start firefox
//        url "http://lefthandedgoat.github.io/canopy/testpages/"
//        "#welcome" == "Welcome"
