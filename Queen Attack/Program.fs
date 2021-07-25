// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

[<EntryPoint>]
let main argv =
    let random = new System.Random()

    let makeRandomPos () =
        [ random.Next(0, 8); random.Next(0, 8) ]

    let w = makeRandomPos ()
    let b = makeRandomPos ()
    let dx = abs (b.[0] - w.[0])
    let dy = abs (b.[1] - w.[1])
    printfn "WHITE: %d,%d" w.[0] w.[1]
    printfn "BLACK: %d,%d" b.[0] b.[1]
    printfn "Matched horizontal or vertical: %b" ((w.[0] = b.[0]) || (w.[1] = b.[1]))
    printfn "Matched diagonal: %b" (dx = dy)

    let posMatchesWhite x y = x = w.[0] && y = w.[1]
    let posMatchesBlack x y = x = b.[0] && y = b.[1]

    for i = 0 to 7 do
        printf "\n"

        for j = 0 to 7 do
            if posMatchesWhite i j then printf "W"
            elif posMatchesBlack i j then printf "B"
            else printf "-"

    0 // return an integer exit code
