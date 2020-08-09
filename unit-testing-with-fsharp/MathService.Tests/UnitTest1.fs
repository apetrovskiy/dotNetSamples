module MathService.Tests

open NUnit.Framework

[<TestFixture>]
type TestClass () =
    [<Test>]
    member this.TestMethodPassing() =
        Assert.True(true)
    
    [<Test>]
    member this.FailEveryTime() = Assert.True(false)

    [<Test>]
    member this.TestEvenSequence() =
        let expected = Seq.empty<int> |> Seq.toList
        let actual = MyMath.squaresOfOdds [2; 4; 6; 8; 10]
        Assert.AreEqual(expected, actual)

(*
[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    Assert.Pass()
*)
