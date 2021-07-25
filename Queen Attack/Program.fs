open System
let length = 8

[<EntryPoint>]
let main argv =
    let random = Random()

    let makeRandomPos () =
        (random.Next(1, length + 1), random.Next(1, length + 1))

    let whitePos = makeRandomPos ()
    let blackPos = makeRandomPos ()
    let (wx, wy) = whitePos
    let (bx, by) = blackPos

    printfn "WHITE: %d,%d" wx wy
    printfn "BLACK: %d,%d" bx by
    printfn "Matched horizontal or vertical: %b" ((wx = bx) || (wy = by))
    printfn "Matched diagonal: %b" (abs (bx - wx) = abs (by - wy))

    let posMatchesWhite pos = pos = whitePos
    let posMatchesBlack pos = pos = blackPos

    for y in 1 .. length do
        printf "\n"

        for x in 1 .. length do
            let pos = (x, y)

            match pos with
            | pos when posMatchesWhite pos -> "W"
            | pos when posMatchesBlack pos -> "B"
            | _ -> "-"
            |> printf "%s"

    0
