open System.IO
open Sudoku

[<EntryPoint>]
let main argv =
    let sudokuBoardText = File.ReadAllText "sudoku.txt"
    do printfn "%s" sudokuBoardText

    let token = 1 |> Cell.create |> Cell.render
    do printfn "Token: %A" token

    0