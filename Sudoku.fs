namespace Sudoku

open System.Collections

type Cell =
    | ProvidedCell of int
    | InputCell of int
    | EmptyCell

module Cell =
    let private check n = 1 <= n && n <= 9

    let provide n =
        if check n
        then ProvidedCell n
        else EmptyCell

    let input n =
        if check n
        then InputCell n
        else EmptyCell

    let value cell =
        match cell with
        | ProvidedCell n -> n
        | InputCell n -> n
        | EmptyCell -> 0

    let render cell =
        match cell with
        | ProvidedCell n ->
            // Value in bold font weight (\x1b is "escape")
            sprintf "\x1b[1m%d\x1b[0m" n
        | InputCell n -> sprintf "%d" n
        | EmptyCell -> " "

type CellLocation = int * int

module Board =
    let create puzzle =
        puzzle
        |> Array2D.map Cell.provide

    let guess value ((x, y): CellLocation) (board: Cell[,]) =
        board.[x, y] <- Cell.input value

    let check (x, y) (board: Cell[,]) =
        let subgrid =
            match x / 3, y / 3 with
            | 0, 0 -> board.[0..2, 0..2]
            | 0, 1 -> board.[0..2, 3..5]
            | 0, 2 -> board.[0..2, 6..8]
            | 1, 0 -> board.[3..5, 0..2]
            | 1, 1 -> board.[3..5, 3..5]
            | 1, 2 -> board.[3..5, 6..8]
            | 2, 0 -> board.[6..8, 0..2]
            | 2, 1 -> board.[6..8, 3..5]
            | 2, 2 -> board.[6..8, 6..8]
            | _, _ -> failwith "Unexpected coordinates"
        let column: Cell[] = board.[x, *]
        let row: Cell[] = board.[*, y]

        let sumCells: (IEnumerable -> int) = Seq.cast<Cell> >> Seq.map Cell.value >> Seq.sum

        sumCells subgrid = 45 && sumCells column = 45 && sumCells row = 45
