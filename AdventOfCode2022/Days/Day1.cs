namespace AdventOfCode2022.Days;

public class Day1 : DayBase<string, int>
{
    public Day1(string fileLocation) : base(FileHandler.GetFileContentsWithBlankLineSeparator(fileLocation))
    {
    }

    public override int Part1()
    {
        FileContents.ForEach(Console.WriteLine);
        var largestCalories = 0;
        foreach (var line in FileContents)
        {
            var amounts = line.Split(' ').ToList();
            amounts.ForEach(Console.WriteLine);
            var amount = line.Split(' ').Sum(x => !string.IsNullOrWhiteSpace(x) ? int.Parse(x) : 0);

            if (amount > largestCalories)
            {
                largestCalories = amount;
            }
        }
        return largestCalories;
    }

    // Top three elves
    public override int Part2()
    {
        var elfAmounts = FileContents.Select(line => line.Split(' ').Sum(x => !string.IsNullOrWhiteSpace(x) ? int.Parse(x) : 0)).ToList();

        elfAmounts.Sort();

        var lastIndex = elfAmounts.Count - 1;

        return elfAmounts[lastIndex] + elfAmounts[lastIndex - 1] + elfAmounts[lastIndex - 2];
    }
}