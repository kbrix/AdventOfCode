module Year2022Tests.Problem5Tests

open NUnit.Framework
open Year2022

[<Test>]
let ExamplePart1 () =
    let data = Problem5Data.exampleData()
    let instruction = Problem5Data.exampleInstruction
    Assert.That(Problem5.solutionPart1 data instruction, Is.EqualTo("CMZ"))
    
[<Test>]
let SolutionPart1 () =
    let data = Problem5Data.inputData()
    let instruction = Problem5Data.inputInstruction
    Assert.That(Problem5.solutionPart1 data instruction, Is.EqualTo("GRTSWNJHH"))
    
[<Test>]
let ExamplePart2 () =
    let data = Problem5Data.exampleData()
    let instruction = Problem5Data.exampleInstruction
    Assert.That(Problem5.solutionPart2 data instruction, Is.EqualTo("MCD"))

[<Test>]
let SolutionPart2 () =
    let data = Problem5Data.inputData()
    let instruction = Problem5Data.inputInstruction
    Assert.That(Problem5.solutionPart2 data instruction, Is.EqualTo("QLFQDBBHM"))    