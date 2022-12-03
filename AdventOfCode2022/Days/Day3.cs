namespace AdventOfCode2022.Days;

public class Day3 : DayBase<string, int>
{
    public Day3(string fileLocation) : base(FileHandler.GetFileContentsAsStrings(fileLocation))
    {
    }

    // First half of line = first compartment
    // Second half of line = second compartment
    // Priorities a -> z = 1 -> 26  
    // Priorities A -> = 27 -> 52
    // Find items in both compartments, add their priorities
    public override int Part1()
    {
        var totalPriority = 0;

        FileContents.ForEach(x =>
        {
            var lineLength = x.Length;
            var firstItem = x[..(lineLength / 2)];
            var lastItem = x[(lineLength / 2)..];

            var commonCharacter = GetCommonCharacterBetween2Items(firstItem, lastItem);
            
            totalPriority += GetPriority(commonCharacter);
        });

        return totalPriority;
    }

    public override int Part2()
    {
        var totalPriority = 0;

        for (var i = 0; i < FileContents.Count; i += 3)
        {
            var firstItem = FileContents[i];
            var secondItem = FileContents[i + 1];
            var thirdItem = FileContents[i + 2];

            var commonCharacter = GetCommonCharacterBetween3Items(firstItem, secondItem, thirdItem);
            
            totalPriority += GetPriority(commonCharacter);
        }

        return totalPriority;
    }
    
    // It would be relatively easy for this to do process of elimination down to 1 character for x items but i'm fucking LAZY
    private static char GetCommonCharacterBetween2Items(string item1, string item2)
    {
        foreach (var character in item1.Where(item2.Contains))
        {
            return character;
        }

        throw new Exception("No common characters found!");
    }

    private static char GetCommonCharacterBetween3Items(string item1, string item2, string item3)
    {
        var commonCharacters = item1.Where(item2.Contains).ToList();

        foreach (var character in commonCharacters.Where(item3.Contains))
        {
            return character;
        }

        throw new Exception("No common characters found!");
    }

    private static int GetPriority(char character)
    {
        var characterIsUppercase = char.IsUpper(character);
        var basePriority = character % 32;
        
        return characterIsUppercase ? basePriority + 26 : basePriority;
    }
}