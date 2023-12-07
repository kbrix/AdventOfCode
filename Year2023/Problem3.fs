module Year2023.Problem3

open System

let isSymbol (x: string) =
    match x with
    | "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" 
    | "." ->
        false
    | _ ->
        true

let isNumber (x: string) =
    match x with 
    | "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" ->
        true
    | _ ->
        false
    
let adjacentElements i j (data: 'a array2d) =
    let I = (data.GetLength 0) - 1
    let J = (data.GetLength 1) - 1        
    [
        // upper left corner cases
        if i - 1 >= 0 then
            yield (i - 1, j)
        if j - 1 >= 0 then
            yield (i, j - 1)
        if i - 1 >= 0 && j - 1 >= 0 then
            yield (i - 1, j - 1)  
        // lower right corner cases
        if i + 1 <= I then
            yield (i + 1, j)
        if j + 1 <= J then
            yield (i, j + 1)
        if i + 1 <= I && j + 1 <= J then
            yield (i + 1, j + 1)
        // lower left corner
        if i + 1 <= I && j - 1 >= 0 then
            yield (i + 1, j - 1)
        // upper right corner
        if i - 1 >= 0 && j + 1 <= J then
            yield (i - 1, j + 1)
    ]

let adjacentColumnElements (j: int) (J: int) =
    match (j - 1 >= 0, j + 1 <= J) with
    | true,  true ->  [ j - 1; j + 1 ]
    | true,  false -> [ j - 1 ]
    | false, true ->  [ j + 1 ]
    | false, false -> []

let discoverAdjacentColumnNumbers (stringData: string array2d) (boolData: bool array2d) =
    let I = (boolData.GetLength 0) - 1
    let J = (boolData.GetLength 1) - 1
    let rec discoverAdjacentColumnNumbersRecursive (matrix: bool array2d) b =
        let mutable update = false
        if not b then
            matrix
        else
            for i in 0 .. I do
                for j in 0 .. J do
                    if matrix[i, j] then
                        adjacentColumnElements j J
                        |> List.iter (fun column ->
                            if isNumber stringData[i, column] && not matrix[i, column] then
                                update <- true
                                matrix[i, column] <- true)
            discoverAdjacentColumnNumbersRecursive matrix update
    discoverAdjacentColumnNumbersRecursive boolData true

let parseAndSumNumbers (strings: string list) =
    let pairs = strings |> List.map (fun str -> Int32.TryParse str)
    let rec parseAndSumNumbersRecursive l s =
        match l with
        | (x, a) :: (y, b) :: (z, c) :: tail when x && y && z ->
            let sum = 100 * a + 10 * b + c
            parseAndSumNumbersRecursive tail (s + sum)
        | (x, a) :: (y, b) :: tail when x && y ->
            let sum = 10 * a + b
            parseAndSumNumbersRecursive tail (s + sum)
        | (x, a) :: tail when x ->
            let sum = a
            parseAndSumNumbersRecursive tail (s + sum)
        | (x, _) :: tail when not x ->
            parseAndSumNumbersRecursive tail s
        | [] ->
            s
        | _ ->
            failwith "👻"
    parseAndSumNumbersRecursive pairs 0

let solution (stringData: string array2d) =
    
    let I = (stringData.GetLength 0) - 1
    let J = (stringData.GetLength 1) - 1
    
    let isNumberAdjacentToSymbol = Array2D.create (I + 1) (J + 1) false
    
    for i in 0 .. I do
        for j in 0 .. J do
            if isSymbol stringData[i, j] then
                stringData
                |> adjacentElements i j
                |> List.iter (fun (x, y) ->
                    if isNumber stringData[x, y] then
                        isNumberAdjacentToSymbol[x, y] <- true)
            
    let isValidNumber = discoverAdjacentColumnNumbers stringData isNumberAdjacentToSymbol
    
    for i in 0 .. I do
        for j in 0 .. J do
            if not isValidNumber[i, j] then
                stringData[i, j] <- "."
    
    let mutable sumPart1 = 0
    for i in 0 .. I do
        let row = Array.toList stringData[i, *]
        sumPart1 <- sumPart1 + parseAndSumNumbers row
    
    sumPart1