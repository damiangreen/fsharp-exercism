open System

[<EntryPoint>]
let main argv =
    let random = Random()

    let makeRandomPos () = (random.Next(0, 8), random.Next(0, 8))

    let (wx, wy) = makeRandomPos ()
    let (bx, by) = makeRandomPos ()

    printfn "WHITE: %d,%d" wx wy
    printfn "BLACK: %d,%d" bx by
    printfn "Matched horizontal or vertical: %b" ((wx = bx) || (wy = by))
    printfn "Matched diagonal: %b" (abs (bx - wx) = abs (by - wy))

    let posMatchesWhite (x, y) = x = wx && y = wy
    let posMatchesBlack (x, y) = x = bx && y = by

    for i in 0 .. 7 do
        printf "\n"

        for j in 0 .. 7 do
            let pos = (i, j)

            match pos with
            | pos when posMatchesWhite pos -> "W"
            | pos when posMatchesBlack pos -> "B"
            | _ -> "-"
            |> printf "%s"

    0
