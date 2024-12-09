
namespace AdventOfCode2024._6;

public static class December6_PartOne
{
    private static List<List<char>> map = new();
    public static int maxRows => map.Count - 1;
    public static int maxCols => map[0].Count - 1;

    private static char UpSymbol = '^';
    private static char RightSymbol = '>';
    private static char LeftSymbol = '<';
    private static char DownSymbol = 'v';
    private static char currentGuardSymbol = '^';
    private static bool nextStepIsObsticle;
    private static (int row, int col) currentPosition = (0, 0);
    private static bool GuardLeft;


    public static int PredictGuardsRoute()
    {
        string content = File.ReadAllText("../../../6/PuzzleInput.txt");
        string? line;

        using (StringReader reader = new StringReader(content))
        {
            while ((line = reader.ReadLine()) != null)
            {
                map.Add(line.ToList());
            }

            FindStart();
            Console.WriteLine($"Starting position: {currentPosition}");


            while (!GuardLeft)
            {
                if (nextStepIsObsticle)
                {
                    TurnRight();
                }

                MoveGuard();
            }

        }
        PrintMap();
        return CountNumberOfSteps();
    }

    private static void TurnRight()
    {
        switch (currentGuardSymbol)
        {
            case '^':
                currentGuardSymbol = RightSymbol;
                break;
            case '>':
                currentGuardSymbol = DownSymbol;
                break;
            case '<':
                currentGuardSymbol = UpSymbol;
                break;
            case 'v':
                currentGuardSymbol = LeftSymbol;
                break;
        }
    }

    private static void MoveGuard()
    {
        switch (currentGuardSymbol)
        {
            case '^':
                if (!OutOfBounds((currentPosition.row - 1, currentPosition.col)))
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    map[currentPosition.row - 1][currentPosition.col] = UpSymbol;

                    currentPosition = (currentPosition.row - 1, currentPosition.col);
                    (int row, int col) nextStep = (currentPosition.row - 1, currentPosition.col);
                    if (!OutOfBounds(nextStep))
                    {
                        nextStepIsObsticle = map[nextStep.row][nextStep.col] == '#';
                    }
                }
                else
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    GuardLeft = true;
                }

                break;

            case '>':
                if (!OutOfBounds((currentPosition.row, currentPosition.col + 1)))
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    map[currentPosition.row][currentPosition.col + 1] = RightSymbol;

                    currentPosition = (currentPosition.row, currentPosition.col + 1);
                    (int row, int col) nextStep = (currentPosition.row, currentPosition.col + 1);
                    if (!OutOfBounds(nextStep))
                    {
                        nextStepIsObsticle = map[nextStep.row][nextStep.col] == '#';
                    }
                }
                else
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    GuardLeft = true;
                }


                break;
            case '<':
                if (!OutOfBounds((currentPosition.row, currentPosition.col - 1)))
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    map[currentPosition.row][currentPosition.col - 1] = LeftSymbol;

                    currentPosition = (currentPosition.row, currentPosition.col - 1);

                    (int row, int col) nextStep = (currentPosition.row, currentPosition.col - 1);
                    if (!OutOfBounds(nextStep))
                    {
                        nextStepIsObsticle = map[nextStep.row][nextStep.col] == '#';
                    }
                }
                else
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    GuardLeft = true;
                }


                break;
            case 'v':
                if (!OutOfBounds((currentPosition.row + 1, currentPosition.col)))
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    map[currentPosition.row + 1][currentPosition.col] = DownSymbol;

                    currentPosition = (currentPosition.row + 1, currentPosition.col);

                    (int row, int col) nextStep = (currentPosition.row + 1, currentPosition.col);
                    if (!OutOfBounds(nextStep))
                    {
                        nextStepIsObsticle = map[nextStep.row][nextStep.col] == '#';
                    }
                }
                else
                {
                    map[currentPosition.row][currentPosition.col] = 'X';
                    GuardLeft = true;
                }


                break;
        }
    }

    private static void FindStart()
    {
        foreach (var line in map)
        {
            foreach (var character in line.Where(character => character == UpSymbol ||
                                                              character == RightSymbol ||
                                                              character == LeftSymbol ||
                                                              character == DownSymbol))
            {
                currentPosition = (map.IndexOf(line), (line.IndexOf(character)));
            }
        }
    }

    private static bool OutOfBounds((int row, int col) position)
    {
        if (position.row < 0 || position.row > maxRows) return true;
        if (position.col < 0 || position.col > maxCols) return true;

        return false;
    }

    private static int CountNumberOfSteps()
    {
        int sum = 0;
        foreach (var line in map)
        {
            foreach (var character in line)
            {
                if (character == 'X') sum++;
            }
        }
        return sum;
    }
    
    private static void PrintMap()
    {
        string mapLine = "";
        foreach (var line in map)
        {
            foreach (var position in line)
            {
                mapLine += position;
            }

            Console.WriteLine(mapLine);
            mapLine = "";
        }
    }
}