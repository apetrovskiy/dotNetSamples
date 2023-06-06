namespace BookstoreApi_f.Models

open System

[<CLIMutable>]
type Book =
    { Id: int
      Title: string
      Author: string
      Price: decimal }
