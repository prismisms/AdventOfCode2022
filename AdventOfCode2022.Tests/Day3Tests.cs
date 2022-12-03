using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day3Tests
{
    private readonly Day3 _day3 = new("TestData/Day3.txt");

    [Fact]
    public void Part1()
    {
        var part1Result = _day3.Part1();
        part1Result.Should().Be(157);
    }
    
    [Fact]
    public void Part2()
    {
        var part2Result = _day3.Part2();
        part2Result.Should().Be(70);
    }
}