namespace Sudoku

type Cell =
    | ProvidedCell of int
    | InputCell of int
    | EmptyCell

module Cell =
    let private check n =
        if 1 <= n && n <= 9
        then Some n
        else None

    let provide n =
        match check n with
        | Some _ -> ProvidedCell n
        | None -> failwith "Invalid value for ProvidedCell"

    let input n =
        match check n with
        | Some _ -> InputCell n
        | None -> EmptyCell

    let render cell =
        match cell with
        | ProvidedCell n ->
            // Value in bold font weight (\x1b is "escape")
            sprintf "\x1b[1m%d\x1b[0m" n
        | InputCell n -> sprintf "%d" n
        | EmptyCell -> " "
