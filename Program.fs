open System.IO
open Sudoku

[<EntryPoint>]
let main argv =
    let sudokuBoardText = File.ReadAllText "sudoku.txt"
    do printfn "%s" sudokuBoardText

    let token0 = 0 |> Cell.input |> Cell.render
    do printfn "0 |> Cell.input |> Cell.render: %s" token0

    let token1 = 1 |> Cell.input |> Cell.render
    do printfn "1 |> Cell.input |> Cell.render: %s" token1

    let tokenP1 = 1 |> Cell.provide |> Cell.render
    do printfn "1 |> Cell.provide |> Cell.render: %s" tokenP1

    let cells = [0..9] |> List.map Cell.input
    do printfn "All Cells:\n%A" cells

    let board =
        array2D [
            [0; 0; 0;  1; 0; 0;  0; 0; 0]
            [0; 0; 0;  2; 0; 0;  0; 0; 0]
            [0; 0; 0;  9; 0; 0;  0; 0; 0]

            [0; 0; 0;  7; 0; 0;  0; 0; 0]
            [0; 0; 0;  8; 0; 0;  0; 0; 0]
            [0; 0; 0;  3; 0; 0;  0; 0; 0]

            [0; 0; 0;  5; 0; 0;  0; 0; 0]
            [0; 0; 0;  4; 0; 0;  0; 0; 0]
            [0; 0; 0;  6; 0; 0;  0; 0; 0]
        ] |> Board.create
    do printfn "Sample board:\n%A" board

    do Board.guess 4 (0, 0) board
    do printfn "Board After Guess:\n%A" board

    0
