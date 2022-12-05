namespace AdventOfCode2022.Days;

public class Day4 : DayBase<string, int>
{
    public Day4(string fileLocation) : base(FileHandler.GetFileContentsAsStrings(fileLocation))
    {
    }

    // Input, line by line looks like 2-3,4-6
    // Two assignments per line
    // How many assignments fully contain another?
    public override int Part1()
    {
        var numberOfFullyContainedAssignments = 0;
        FileContents.ForEach(x =>
        {
            var (firstAssignmentRange, secondAssignmentRange) = GetAssignmentRanges(x);

            if ((firstAssignmentRange.First()<= secondAssignmentRange.First() 
                           && firstAssignmentRange.Last() >= secondAssignmentRange.Last())
                 || (firstAssignmentRange.First() >= secondAssignmentRange.First() 
                     && firstAssignmentRange.Last() <= secondAssignmentRange.Last()))
            {
                numberOfFullyContainedAssignments++;
            }
        });

        return numberOfFullyContainedAssignments;
    }

    // Find any overlap at all
    public override int Part2()
    {
        var numberOfOverlappingAssignments = 0;
        FileContents.ForEach(x =>
        {
            var (firstAssignmentRange, secondAssignmentRange) = GetAssignmentRanges(x);

            // Full overlap
            if ((firstAssignmentRange.First()<= secondAssignmentRange.First() 
                 && firstAssignmentRange.Last() >= secondAssignmentRange.Last())
                || (firstAssignmentRange.First() >= secondAssignmentRange.First() 
                    && firstAssignmentRange.Last() <= secondAssignmentRange.Last()))
            {
                numberOfOverlappingAssignments++;
            }
            // Partial overlap
            else if ((firstAssignmentRange.First() >= secondAssignmentRange.First() && firstAssignmentRange.First() <=secondAssignmentRange.Last())
                     || firstAssignmentRange.Last() <= secondAssignmentRange.Last() && firstAssignmentRange.Last() >= secondAssignmentRange.First())
            {
                numberOfOverlappingAssignments++;
            }
        });

        return numberOfOverlappingAssignments;    
    }

    private static (IEnumerable<int>, IEnumerable<int>) GetAssignmentRanges(string input)
    {
        var assignments = input.Split(',');

        var firstAssignmentRange = assignments[0].Split('-');
        var secondAssignmentRange = assignments[1].Split('-');

        return (firstAssignmentRange.Select(int.Parse), secondAssignmentRange.Select(int.Parse));
    }
}