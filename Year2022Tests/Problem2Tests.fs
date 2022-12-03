module Year2022Tests.Problem2Tests

open NUnit.Framework
open Year2022

[<Test>]
let ExamplePart1 () =
    Assert.That(Problem2.solutionPart1 Problem2Data.exampleData, Is.EqualTo(15))

[<Test>]
let ExamplePart2 () =
    Assert.That(Problem2.solutionPart2 Problem2Data.exampleData, Is.EqualTo(12))

[<Test>]
let AnswerPart1 () =
    Assert.That(Problem2.solutionPart1 Problem2Data.inputData, Is.EqualTo(12458))
    
[<Test>]
let AnswerPart2 () =
    Assert.That(Problem2.solutionPart2 Problem2Data.inputData, Is.EqualTo(12683))
