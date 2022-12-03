module Year2022.Problem2

type Move =
    | Rock
    | Paper
    | Scissors

let parseMove (value: char) =
    match value with
    | 'A'
    | 'X' -> Rock
    | 'B'
    | 'Y' -> Paper
    | 'C'
    | 'Z' -> Scissors
    | _ -> failwith "Unsupported value cannot be parsed!"

let getMoveScore move =
    match move with
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let getPlayerScoreForMatch opponent player =
    match opponent, player with
    // Player wins
    | Rock, Paper
    | Paper, Scissors
    | Scissors, Rock -> 6
    // Opponent wins
    | Rock, Scissors
    | Paper, Rock
    | Scissors, Paper -> 0
    // Draw
    | _ -> 3

let solutionPart1 (data: string []) : int =
    let playerScores =
        data
        |> Array.map (fun d ->
            let opponent = parseMove d[0]
            let player = parseMove d[1]

            let playerScore =
                getMoveScore player
                + getPlayerScoreForMatch opponent player

            playerScore)

    Array.sum playerScores

type Strategy =
    | Lose
    | Draw
    | Win

let parseStrategy (value: char) =
    match value with
    | 'X' -> Lose
    | 'Y' -> Draw
    | 'Z' -> Win
    | _ -> failwith "Unsupported value cannot be parsed!"

let getPlayerMoveWithStrategy opponent player =
    match opponent, player with
    // Opponent plays rock
    | Rock, Lose -> Scissors
    | Rock, Win -> Paper
    // Opponent plays paper
    | Paper, Lose -> Rock
    | Paper, Win -> Scissors
    // Opponent plays scissors
    | Scissors, Lose -> Paper
    | Scissors, Win -> Rock
    // Force a draw no matter what the opponent plays
    | _, Draw -> opponent

let solutionPart2 (data: string []) : int =
    let playerScores =
        data
        |> Array.map (fun d ->
            let opponentMove = parseMove d[0]
            let playerStrategy = parseStrategy d[1]

            let playerMove =
                getPlayerMoveWithStrategy opponentMove playerStrategy

            let playerScore =
                getMoveScore playerMove
                + getPlayerScoreForMatch opponentMove playerMove

            playerScore)

    Array.sum playerScores
