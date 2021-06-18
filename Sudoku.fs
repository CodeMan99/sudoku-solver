namespace Sudoku

open System

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
