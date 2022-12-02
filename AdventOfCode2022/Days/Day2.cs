namespace AdventOfCode2022.Days;

public class Day2 : DayBase<string, int>
{
    public Day2(string fileLocation) : base(FileHandler.GetFileContentsAsStrings(fileLocation))
    {
    }

    public override int Part1()
    {
        // Rock = 1 (A, X) <- i could probably do an enum where A = X
        // Paper = 2 (B, Y)
        // Scissors = 3 (C, Z)
        // Loss = 0
        // Draw = 3
        // Win = 6
        // Rock wins against Scissors, Scissors win against Paper, Paper wins against Rock
        
        // Need total score
        var totalScore = 0;
        FileContents.ForEach(x =>
        {
            var opponent = Enum.Parse<RockPaperScissors>(x[0].ToString());
            var mine = Enum.Parse<RockPaperScissors>(x[2].ToString());

            switch (mine)
            {
                case RockPaperScissors.X:
                    switch (opponent)
                    {
                        case RockPaperScissors.A:
                            totalScore += (int)mine + 3;
                            break;
                        case RockPaperScissors.B:
                            totalScore += (int) mine;
                            break;
                        case RockPaperScissors.C:
                            totalScore += (int)mine + 6;
                            break;
                    }

                    break;
                case RockPaperScissors.Y:
                    switch (opponent)
                    {
                        case RockPaperScissors.A:
                            totalScore += (int) mine + 6;
                            break;
                        case RockPaperScissors.B:
                            totalScore += (int) mine + 3;
                            break;
                        case RockPaperScissors.C:
                            totalScore += (int) mine;
                            break;
                    }

                    break;
                case RockPaperScissors.Z:
                    switch (opponent)
                    {
                        case RockPaperScissors.A:
                            totalScore += (int)mine;
                            break;
                        case RockPaperScissors.B:
                            totalScore += (int) mine + 6;
                            break;
                        case RockPaperScissors.C:
                            totalScore += (int) mine + 3;
                            break;
                    }

                    break;
            }
        });
        
        return totalScore;
    }

    // The second part actually says what the result should be
    // X = lose
    // Y = draw
    // Z = win
    public override int Part2()
    {
        var totalScore = 0;
        FileContents.ForEach(x =>
        {
            var opponent = x[0];
            var result = x[2];

            switch (result)
            {
                // lose
                case 'X':
                    totalScore += opponent switch
                    {
                        'A' => (int) RockPaperScissors.C,
                        'B' => (int) RockPaperScissors.A,
                        _ => (int) RockPaperScissors.B
                    };
                    break;
                // draw
                case 'Y' when opponent == 'A':
                    totalScore += (int) RockPaperScissors.A + 3;
                    break;
                case 'Y' when opponent == 'B':
                    totalScore += (int) RockPaperScissors.B + 3;
                    break;
                case 'Y':
                    totalScore += (int) RockPaperScissors.C + 3;
                    break;
                // win
                default:
                {
                    totalScore += opponent switch
                    {
                        'A' => (int) RockPaperScissors.B + 6,
                        'B' => (int) RockPaperScissors.C + 6,
                        _ => (int) RockPaperScissors.A + 6
                    };

                    break;
                }
            }
        });

        return totalScore;
    }

    private enum RockPaperScissors
    {
        A = 1,
        X = 1,
        B = 2,
        Y = 2,
        C = 3,
        Z = 3
    }
}