namespace MathService

module MyMath =
    let private isOdd x = x % 2 <> 0
    let squaresOfOdds xs =
        xs
        |> Seq.filter isOdd
