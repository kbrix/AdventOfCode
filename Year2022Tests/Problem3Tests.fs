module Year2022Tests.Problem3Tests

open NUnit.Framework
open Year2022
    
[<Test>]
let ExamplePart1 () =
    Assert.That(Problem3.solutionPart1 Problem3Data.exampleData, Is.EqualTo(157))

[<Test>]
let SolutionPart1 () =
    Assert.That(Problem3.solutionPart1 Problem3Data.inputData, Is.EqualTo(7597))
    
[<Test>]
let ExamplePart2 () =
    Assert.That(Problem3.solutionPart2 Problem3Data.exampleData, Is.EqualTo(70))
    
[<Test>]
let SolutionPart2 () =
    Assert.That(Problem3.solutionPart2 Problem3Data.inputData, Is.EqualTo(2607))