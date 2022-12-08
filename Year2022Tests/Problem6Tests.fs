module Year2022Tests.Problem6Tests

open NUnit.Framework
open Year2022

[<TestCase(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")>]
[<TestCase(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")>]
[<TestCase(6, "nppdvjthqldpwncqszvftbrmjlhg")>]
[<TestCase(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")>]
[<TestCase(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")>]
let ExamplePart1 (expectedValue, exmapleData) =
    Assert.That(Problem6.solution exmapleData 4, Is.EqualTo(expectedValue))
    
[<Test>]
let SolutionPart1 () =
    Assert.That(Problem6.solution Problem6Data.inputData 4, Is.EqualTo(1042))
    
[<TestCase(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")>]
[<TestCase(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")>]
[<TestCase(23, "nppdvjthqldpwncqszvftbrmjlhg")>]
[<TestCase(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")>]
[<TestCase(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")>]
let ExamplePart2 (expectedValue, exmapleData) =
    Assert.That(Problem6.solution exmapleData 14, Is.EqualTo(expectedValue))
    
[<Test>]
let SolutionPart2 () =
    Assert.That(Problem6.solution Problem6Data.inputData 14, Is.EqualTo(2980))