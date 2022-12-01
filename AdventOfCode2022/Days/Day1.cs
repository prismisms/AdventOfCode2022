namespace AdventOfCode2022.Days;

public class Day1 : DayBase<string, int>
{
    public Day1(string fileLocation) : base(FileHandler.GetFileContentsWithBlankLineSeparator(fileLocation))
    {
    }

    public override int Part1() => FileContents.Select(line => line.Split(' ').Sum(x => !string.IsNullOrWhiteSpace(x) ? int.Parse(x) : 0)).Prepend(0).Max();

    // Top three elves
    public override int Part2()
    {
        var elfAmounts = FileContents.Select(line => line.Split(' ').Sum(x => !string.IsNullOrWhiteSpace(x) ? int.Parse(x) : 0)).ToList();

        elfAmounts.Sort();

        var lastIndex = elfAmounts.Count - 1;

        return elfAmounts[lastIndex] + elfAmounts[lastIndex - 1] + elfAmounts[lastIndex - 2];
    }
}