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

let isStar (x: string) =
    x = "*"
    
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

type CoordinateNumberRelation = { Coordinates: (int * int) list; Number: int }
    
let solutionVersion2 (stringData: string array2d) =
    
    let rec parseCoordinateNumberRelationsRecursive
        (row: int) (column: int) (relations: CoordinateNumberRelation list) (rowValueList: (bool * int) list):
        CoordinateNumberRelation list =
        match rowValueList with
        | (x, a) :: (y, b) :: (z, c) :: tail when x && y && z ->
            let number = 100 * a + 10 * b + c
            let coordinates = [ column .. column + 2 ] |> List.map (fun column -> (row, column))
            let relation = { Number = number; Coordinates = coordinates }
            parseCoordinateNumberRelationsRecursive row (column + 3) (relations @ [relation]) tail
        | (x, a) :: (y, b) :: tail when x && y ->
            let number = 10 * a + b
            let coordinates = [ column .. column + 1 ] |> List.map (fun column -> (row, column))
            let relation = { Number = number; Coordinates = coordinates }
            parseCoordinateNumberRelationsRecursive row (column + 2) (relations @ [relation]) tail
        | (x, a) :: tail when x ->
            let number = a
            let coordinates = [ (row, column) ]
            let relation = { Number = number; Coordinates = coordinates }
            parseCoordinateNumberRelationsRecursive row (column + 1) (relations @ [relation]) tail
        | (x, _) :: tail when not x ->
            parseCoordinateNumberRelationsRecursive row (column + 1) relations tail
        | [] ->
            relations
        | _ ->
            failwith "👻"
    
    let I = (stringData.GetLength 0) - 1
    let J = (stringData.GetLength 1) - 1
    
    let coordinateNumberMap =
        [0 .. I]
        |> List.map (fun row ->
            Array.toList stringData[row, *]
            |> List.map (fun str -> Int32.TryParse str)
            |> parseCoordinateNumberRelationsRecursive row 0 [])
        |> List.collect id
        |> List.map (fun relation ->
            relation.Coordinates
            |> List.map (fun coordinate -> coordinate, relation.Number))
        |> List.collect id
        |> Map
    
    let solution1 =
        [ for i in 0 .. I do for j in 0 .. J do yield (i, j) ]
        |> List.filter (fun (i, j) -> isSymbol stringData[i, j])
        |> List.map (fun (i, j) ->
            adjacentElements i j stringData
            |> List.filter (fun (i, j) -> isNumber stringData[i, j])
            |> fun coordinates ->
                coordinates
                |> List.map (fun coordinate -> coordinateNumberMap[coordinate])
                // Assumes that adjacent numbers are unique (this might not be the case and we might to give them an identifier)
                |> List.distinct)
        |> List.collect id
        |> List.sum
            
    let solution2 =
        [ for i in 0 .. I do for j in 0 .. J do yield (i, j) ]
        |> List.filter (fun (i, j) -> isStar stringData[i, j]) // Note the different filter function
        |> List.map (fun (i, j) ->
            adjacentElements i j stringData
            |> List.filter (fun (i, j) -> isNumber stringData[i, j])
            |> fun coordinates ->
                coordinates
                |> List.map (fun coordinate -> coordinateNumberMap[coordinate])
                // Assumes that adjacent numbers are unique (this might not be the case and we might to give them an identifier)
                |> List.distinct)
        |> List.map (fun x -> // Instead of collecting the list of numbers, we first compute a product for a given condition 
            if List.length x = 2 then List.head x * List.last x else 0)
        |> List.sum
    
    solution1, solution2