namespace BookstoreApi_f.Controllers

open System
open Microsoft.AspNetCore.Mvc
open BookstoreApi_f.Models

[<ApiController>]
[<Route("[controller]")>]
type BookstoreController() =
    inherit ControllerBase()

    let _books =
        [| { Id = 1
             Title = "The Catcher in the Rye"
             Author = "J.D. Salinger"
             Price = 9.99m }
           { Id = 2
             Title = "To Kill a Mockingbird"
             Author = "Harper Lee"
             Price = 12.99m }
           { Id = 3
             Title = "1984"
             Author = "George Orwell"
             Price = 7.99m } |]

    [<HttpGet>]
    member _.GetAllBooks() = Ok(_books)
