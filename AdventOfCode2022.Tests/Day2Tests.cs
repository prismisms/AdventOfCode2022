using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day5Tests
{
    private readonly Day2 _day2 = new("TestData/Day2.txt");

    [Fact]
    public void ShouldCalculatePart1Correctly()
    {
        var part1Answer = _day2.Part1();
        part1Answer.Should().Be(15);
    }

    // [Fact]
    // public void ShouldCalculatePart2Correctly()
    // {
    //     var part2Answer = _day2.Part2();
    //     part2Answer.Should().Be(12);
    // }
}