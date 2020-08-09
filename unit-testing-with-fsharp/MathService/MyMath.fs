namespace MathService

module MyMath =
    let square x = x * x
    let private isOdd x = x % 2 <> 0
    let squaresOfOdds xs =
        xs
        |> Seq.filter isOdd
        |> Seq.map square
