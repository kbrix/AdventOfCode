module Year2022.Problem4

let private parsePair (line: string) =
    let splitLine = line.Split(',')
    
    let p1EndPoints = splitLine[0].Split('-')
    let p2EndPoints = splitLine[1].Split('-')
    
    let p1Left, p1Right = p1EndPoints[0], p1EndPoints[1] 
    let p2Left, p2Right = p2EndPoints[0], p2EndPoints[1]
    
    int p1Left, int p1Right, int p2Left, int p2Right

let private isContained (p1Left: int) (p1Right: int) (p2Left: int) (p2Right: int) =
    match p1Left, p1Right, p2Left, p2Right with
    // p2 is contained in p1
    | p1Left, p1Right, p2Left, p2Right
        when p1Left <= p2Left && p2Right <= p1Right -> true
    // p1 is contained in p2
    | p1Left, p1Right, p2Left, p2Right
        when p2Left <= p1Left && p1Right <= p2Right -> true
    | _, _, _, _ -> false

let solutionPart1 (data: string[]) =
    let containments =
        data
        |> Array.map (fun d ->
            let p1Left, p1Right, p2Left, p2Right = parsePair d
            let isContainedInPair = isContained p1Left p1Right p2Left p2Right
            isContainedInPair)
        
    containments
    |> Array.filter (fun x -> x = true)
    |> Array.length

let private isOverlap (p1Left: int) (p1Right: int) (p2Left: int) (p2Right: int) =
    let p1 = [p1Left .. p1Right] |> Set.ofList
    let p2 = [p2Left .. p2Right] |> Set.ofList    
    let intersection = Set.intersect p1 p2
    not <| Set.isEmpty intersection

let solutionPart2 (data: string[]) =
    let overlaps =
        data
        |> Array.map (fun d ->
            let p1Left, p1Right, p2Left, p2Right = parsePair d
            let isOverlapInPair = isOverlap p1Left p1Right p2Left p2Right
            isOverlapInPair)

    overlaps
    |> Array.filter (fun x -> x = true)
    |> Array.length