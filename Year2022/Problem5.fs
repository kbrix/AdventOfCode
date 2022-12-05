module Year2022.Problem5

open System.Collections.Generic

let private parseLine (line: string) =
    let splitLine = line.Split(' ')
    let ``move`` = splitLine[1] |> int
    let ``from`` = splitLine[3] |> int
    let ``to`` = splitLine[5] |> int
    ``move``, ``from``, ``to``

let private arrangeStacksWithCreateMover9000 (data: Stack<string>[]) (parsedInstructions: (int * int * int)[]) =
    let stacks = data
    
    parsedInstructions
    |> Array.iter (fun instruction ->
        let m, f, t = instruction
        // Problem uses 1 as start index, so we need to subtract 1 in array
        for i = 1 to m do
            let value = stacks[f - 1].Pop()
            stacks[t - 1].Push(value))
    
    stacks

let solutionPart1 (data: Stack<string>[]) (instructions: string[]) =   
    let parsedInstructions =
        instructions
        |> Array.map parseLine
        
    let stacks =
        arrangeStacksWithCreateMover9000 data parsedInstructions
    
    let topStackValues =
        stacks
        |> Array.map (fun stack -> stack.Peek())
    
    System.String.Join("", topStackValues)

let private arrangeStacksWithCreateMover9001 (data: Stack<string>[]) (parsedInstructions: (int * int * int)[]) =
    let stacks = data
    
    parsedInstructions
    |> Array.iter (fun instruction ->
        let m, f, t = instruction
        let craneStack = Stack<string>()
        // Problem uses 1 as start index, so we need to subtract 1 in array
        for i = 1 to m do // add elements to crane's stack from
            let value = stacks[f - 1].Pop()
            craneStack.Push(value)
        for i = 1 to m do // then add elements from crane's stack in the order they were popped
            let value = craneStack.Pop()
            stacks[t - 1].Push(value))
    
    stacks

let solutionPart2 (data: Stack<string>[]) (instructions: string[]) =   
    let parsedInstructions =
        instructions
        |> Array.map parseLine
        
    let stacks =
        arrangeStacksWithCreateMover9001 data parsedInstructions
    
    let topStackValues =
        stacks
        |> Array.map (fun stack -> stack.Peek())
    
    System.String.Join("", topStackValues)