module Year2023Tests.Problem3Tests

open System
open NUnit.Framework
open Year2023

[<Test>]
let ExamplePart1 () =
    let result = Problem3.solution Problem3Data.exampleData
    Assert.That(result, Is.EqualTo(4361))
    
[<Test>]
let SolutionPart1 () =
    let result = Problem3.solution Problem3Data.data
    Assert.That(result, Is.EqualTo(498559))