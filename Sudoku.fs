namespace Sudoku

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

    let render cell =
        match cell with
        | ProvidedCell n ->
            // Value in bold font weight (\x1b is "escape")
            sprintf "\x1b[1m%d\x1b[0m" n
        | InputCell n -> sprintf "%d" n
        | EmptyCell -> " "
