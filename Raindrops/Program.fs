(*Introduction
Your task is to convert a number into a string that contains raindrop sounds
corresponding to certain potential factors. A factor is a number that evenly
divides into another number, leaving no remainder. The simplest way to test if a
 one number is a factor of another is to use the modulo operation.

The rules of raindrops are that if a given number:

has 3 as a factor, add 'Pling' to the result.
has 5 as a factor, add 'Plang' to the result.
has 7 as a factor, add 'Plong' to the result.
does not have any of 3, 5, or 7 as a factor, the result should be the digits of the number.
Examples
28 has 7 as a factor, but not 3 or 5, so the result would be "Plong".
30 has both 3 and 5 as factors, but not 7, so the result would be "PlingPlang".
34 is not factored by 3, 5, or 7, so the result would be "34".*)
open System

// Define a function to construct a message to print

[<EntryPoint>]
let main argv =
    let n = argv.[0] |> int
    let noRemainder divisor = n % divisor = 0

    let p = noRemainder 3
    let pl = noRemainder 5
    let plo = noRemainder 7

    let plingIt = if p then "Pling" else ""
    let plangIt = if pl then "Plang" else ""
    let plongIt = if plo then "Plong" else ""

    let digits =
        if not p && not pl && not plo then
            n |> string
        else
            ""

    printf "%s%s%s%s" plingIt plangIt plongIt digits
    0 // return an integer exit code
