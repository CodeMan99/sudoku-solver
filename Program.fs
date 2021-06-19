open System.IO
open Sudoku

[<EntryPoint>]
let main argv =
    let sudokuBoardText = File.ReadAllText "sudoku.txt"
    let empty c = match c with '.' -> ' ' | _ -> c
    do printfn "%s" (sudokuBoardText |> String.map empty)

    let token0 = 0 |> Cell.input |> Cell.render
    do printfn "0 |> Cell.input |> Cell.render: %s" token0

    let token1 = 1 |> Cell.input |> Cell.render
    do printfn "1 |> Cell.input |> Cell.render: %s" token1

    let tokenP1 = 1 |> Cell.provide |> Cell.render
    do printfn "1 |> Cell.provide |> Cell.render: %s" tokenP1

    let cells = [0..9] |> List.map Cell.input
    do printfn "All Cells:\n%A" cells

    0
