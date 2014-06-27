#light
module MyNamespace.MyModule
printfn "Hello world"

/// Split a string into words at spaces
let splitAtSpaces (text: string) =
    text.Split ' '
    |> Array.toList

/// Analyze a string for duplicate words
let wordCount text =
    let words = splitAtSpaces text
    let wordSet = Set.ofList words
    let numWords = words.Length
    let numDups = words.Length - wordSet.Count
    (numWords, numDups)

/// Analyze a string for duplicate words and display the results.
let showWordCount text =
    let numWords, numDups = wordCount text
    printfn "--> %d words in the text" numWords
    printfn "--> %d duplicate words" numDups

showWordCount "sdafds fg sdfgdsfg ssd"

let chrisTest test =
    // test "Chris"
    printfn "%s" (test "Chris")

let isMe x =
    if x = "Chris" then
        "it is Chris!"
    else
        "is' someone else"

let isChris x =
    "Chris"

chrisTest isMe
chrisTest isChris

let add = (fun x y -> x + y)
printfn "%i" (add 2 2)

let twoTest test =
    test 2

printfn "%b" (twoTest (fun x -> x < 0))

let evens = [2; 4; 6; 8]
let firstHundred = [0..100]
let doubled = List.map (fun x -> x * 2) firstHundred

List.map (fun x -> x * 2)
    (List.filter (fun x -> x % 2 = 0) firstHundred)

List.sum (List.map (fun x -> x * 2)
    (List.filter (fun x -> x % 2 = 0) [0..100]))

[0..100]
|> List.filter (fun x -> x % 2 = 0)
|> List.map (fun x -> x * 2)
|> List.sum

printfn "That's all"