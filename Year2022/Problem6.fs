module Year2022.Problem6

let solution (data: string) (marker: int): int =
    let charArray = data.ToCharArray()
    let indexOfWindowWithDistinctValues =
        charArray
        |> Array.toSeq
        |> Seq.windowed marker
        |> Seq.map (fun values ->
            let arrayLength = values |> Array.length
            let distinctArrayLength = values |> Array.distinct |> Array.length
            arrayLength = distinctArrayLength)
        |> Seq.findIndex (fun x -> x = true)
    indexOfWindowWithDistinctValues + marker