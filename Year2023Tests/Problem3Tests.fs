module Year2023Tests.Problem3Tests

open NUnit.Framework
open Year2023

[<Test; Ignore "Use the other version">]
let ExamplePart1 () =
    let result = Problem3.solution Problem3Data.exampleData
    Assert.That(result, Is.EqualTo(4361))
    
[<Test; Ignore "Use the other version">]
let SolutionPart1 () =
    let result = Problem3.solution Problem3Data.data
    Assert.That(result, Is.EqualTo(498559))

[<Test>]
let ExamplePart1Version2 () =
    let result = fst (Problem3.solutionVersion2 Problem3Data.exampleData)
    Assert.That(result, Is.EqualTo(4361))
    
[<Test>]
let SolutionPart1Version2 () =
    let result = fst (Problem3.solutionVersion2 Problem3Data.data)
    Assert.That(result, Is.EqualTo(498559))
    
[<Test>]
let ExamplePart2Version2 () =
    let result = snd (Problem3.solutionVersion2 Problem3Data.exampleData)
    Assert.That(result, Is.EqualTo(467835))
    
[<Test>]
let SolutionPart2Version2 () =
    let result = snd (Problem3.solutionVersion2 Problem3Data.data)
    Assert.That(result, Is.EqualTo(72246648))