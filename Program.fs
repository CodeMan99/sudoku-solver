// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO

type Cell =
    | CompletedCell of int
    | EmptyCell

module Cell =
    let create n =
        if 1 <= n && n <= 9
        then CompletedCell n
        else EmptyCell

    let render cell =
        let value =
            match cell with
            | CompletedCell n -> 0x30 + n
            | EmptyCell -> 0x20
        Convert.ToChar value

[<EntryPoint>]
let main argv =
    let sudokuBoardText = File.ReadAllText "sudoku.txt"
    do printfn "%s" sudokuBoardText

    let token = 1 |> Cell.create |> Cell.render
    do printfn "Token: %A" token

    0