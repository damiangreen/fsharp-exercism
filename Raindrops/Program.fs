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

    let lookup = [ 3, "Pling"; 5, "Plang"; 7, "Plong" ]

    let words =
        lookup
        |> List.map (fun (k, v) -> (if (noRemainder k) then v else ""))
        |> List.filter (fun x -> x <> "") // could this be done more efficiently with a fold or reduce?
        |> String.Concat

    printf
        "%s"
        (if words.Length = 0 then
             n |> string
         else
             words)

    0 // return an integer exit code
