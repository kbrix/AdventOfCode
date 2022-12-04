module Year2022.Problem3

let private splitRuckSackIntoCompartments (rucksack: string) =
    let halfLength = rucksack |> String.length |> fun l -> l / 2
    let compartment1 = rucksack |> Seq.take halfLength |> Set.ofSeq
    let compartment2 = rucksack |> Seq.skip halfLength |> Set.ofSeq
    compartment1, compartment2

let private findCommonItemInCompartments (c1 : Set<char>) (c2 : Set<char>) =
    let commonValue = Set.intersect c1 c2 |> Set.toList |> List.head
    commonValue

let private getPriority c =
    match c with
    | x when x >= 'a' && x <= 'z' -> int x - int 'a' + 1
    | x when x >= 'A' && x <= 'Z' -> int x - int 'A' + 27
    | _ -> invalidArg (nameof(c)) "Cannot convert argument into number!"

let solutionPart1 (data: string[]) =
    let priorities =
        data
        |> Array.map (fun d ->
            let c1, c2 = splitRuckSackIntoCompartments d
            let item = findCommonItemInCompartments c1 c2
            let priority = getPriority item
            priority)
    
    Array.sum priorities

let solutionPart2 (data: string[]) =
    let chunks =
        data
        |> Array.chunkBySize 3
        
    let commonItems =
        chunks
        |> Array.map (fun chunk ->
            let g1 = chunk[0].ToCharArray() |> Set.ofArray
            let g2 = chunk[1].ToCharArray() |> Set.ofArray
            let g3 = chunk[2].ToCharArray() |> Set.ofArray
            let commonItemsInChunk =
                Set.intersectMany (seq { yield g1; yield g2; yield g3 })
            commonItemsInChunk |> Set.toList |> List.head)
        
    let priorities =
        commonItems
        |> Array.map getPriority
        
    Array.sum priorities