module Year2022Tests.Problem4Tests

open NUnit.Framework
open Year2022

[<Test>]
let ExamplePart1 () =
    Assert.That(Problem4.solutionPart1 Problem4Data.exampleData, Is.EqualTo(2))
    
[<Test>]
let SolutionPart1 () =
    Assert.That(Problem4.solutionPart1 Problem4Data.inputData, Is.EqualTo(584))
    
[<Test>]
let ExamplePart2 () =
    Assert.That(Problem4.solutionPart2 Problem4Data.exampleData, Is.EqualTo(4))

[<Test>]
let SolutionPart2 () =
    Assert.That(Problem4.solutionPart2 Problem4Data.inputData, Is.EqualTo(933))