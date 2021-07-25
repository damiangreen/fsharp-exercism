// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let isLeapYear year =
    let r = year % 4 = 0
    let r2 = year % 100 = 0
    let r3 = year % 400 = 0
    r && (not r2 || r3)

(*on every year that is evenly divisible by 4
  except every year that is evenly divisible by 100
    unless the year is also evenly divisible by 400*)
[<EntryPoint>]
let main argv =
    let d = DateTime.Parse argv.[0]
    let result = isLeapYear d.Year
    result |> printfn "%b"

    // printfn "remainder %f" remainder
    0 // return an integer exit code
