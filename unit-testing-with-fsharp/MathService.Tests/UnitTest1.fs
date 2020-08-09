module MathService.Tests

open NUnit.Framework

[<TestFixture>]
type TestClass () =
    [<Test>]
    member this.TestMethodPassing() =
        Assert.True(true)
    
    [<Test>]
    member this.FailEveryTime() = Assert.True(false)

(*
[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    Assert.Pass()
*)
