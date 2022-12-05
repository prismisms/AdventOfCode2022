using AdventOfCode2022.Days;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests;

public class Day4Tests
{
    private readonly Day4 _day4 = new("TestData/Day4.txt");

    [Fact]
    public void Part1()
    {
        var part1Result = _day4.Part1();
        part1Result.Should().Be(2);
    }
    
    [Fact]
    public void Part2()
    {
        var part2Result = _day4.Part2();
        part2Result.Should().Be(4);
    }
}