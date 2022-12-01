module Year2022Tests.Problem1Tests

open NUnit.Framework
open Year2022

[<Test>]
let Example () =
    Assert.That(Problem1.solution Problem1Data.exampleData 1, Is.EqualTo(24000))

[<Test>]
let AnswerPart1 () =
    Assert.That(Problem1.solution Problem1Data.inputData 1, Is.EqualTo(69289))

[<Test>]
let AnswerPart2 () =
    Assert.That(Problem1.solution Problem1Data.inputData 3, Is.EqualTo(205615))
