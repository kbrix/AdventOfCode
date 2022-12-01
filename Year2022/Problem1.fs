module Year2022.Problem1

let solution (data: string []) (n: int) : int =
    let sumArray =
        data
        |> String.concat ","
        |> fun stringConcatenated -> stringConcatenated.Split(",,")
        |> Array.map (fun s ->
            s.Split(",")
            |> Array.map System.Convert.ToInt32
            |> Array.sum)
        |> Array.sortDescending
        |> Array.take n

    let sum = Array.sum sumArray

    if n = 1 then
        printfn $"The elf carrying the most calories is carrying {sum} calories."
    else
        printfn $"The {n} elves carrying the most calories are carrying a combined total of {sum} calories."

    sum
