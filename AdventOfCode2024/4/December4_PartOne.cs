namespace AdventOfCode2024._4;

public static class December4_PartOne
{
    public static List<List<char>> lines = new();
    public static int maxRows => lines.Count - 1;
    public static int maxCols => lines[0].Count - 1;

    public static int FinNumberOfXmasAppearences()
    {
        string content = File.ReadAllText("../../../4/PuzzleInput.txt");
        int sum = 0;
        string input;

        using (StringReader reader = new StringReader(content))
        {
            while ((input = reader.ReadLine()) != null)
            {
                lines.Add(input.ToList());
            }

            int row = 0;
            int col = 0;

            foreach (var line in lines)
            {
                foreach (var letter in line)
                {
                    if (letter == 'X')
                    {
                        sum += CheckUp(row, col);
                        sum += CheckUpRight(row, col);
                        sum += CheckRight(row, col);
                        sum += CheckDownRight(row, col);
                        sum += CheckDown(row, col);
                        sum += CheckDownLeft(row, col);
                        sum += CheckLeft(row, col);
                        sum += CheckUpLeft(row, col);
                    }
                    col++;
                }
                col = 0;
                row++;
            }
        }
        return sum;
    }
    
    private static int CheckDown(int row, int col)
    {
        if (row + 1 > maxRows || lines[row + 1][col] != 'M') return 0;
        if (row + 2 > maxRows || lines[row + 2][col] != 'A') return 0;
        if (row + 3 > maxRows || lines[row + 3][col] != 'S') return 0;
        return 1;
    }
    
    private static int CheckUp(int row, int col)
    {
        if (row - 1 < 0 || lines[row - 1][col] != 'M') return 0;
        if (row - 2 < 0 || lines[row - 2][col] != 'A') return 0;
        if (row - 3 < 0 || lines[row - 3][col] != 'S') return 0;
        return 1;
    }
    
    private static int CheckRight(int row, int col)
    {
        if (col + 1 > maxCols || lines[row][col + 1] != 'M') return 0;
        if (col + 2 > maxCols || lines[row][col + 2] != 'A') return 0;
        if (col + 3 > maxCols || lines[row][col + 3] != 'S') return 0;
        return 1;
    }
    private static int CheckLeft(int row, int col)
    {
        if (col - 1 < 0 || lines[row][col - 1] != 'M') return 0;
        if (col - 2 < 0 || lines[row][col - 2] != 'A') return 0;
        if (col - 3 < 0 || lines[row][col - 3] != 'S') return 0;
        return 1;
    }
    private static int CheckUpLeft(int row, int col)
    {
        if (row - 1 < 0 || col - 1 < 0 || lines[row - 1][col - 1] != 'M') return 0;
        if (row - 2 < 0 || col - 2 < 0 || lines[row - 2][col - 2] != 'A') return 0;
        if (row - 3 < 0 || col - 3 < 0 || lines[row - 3][col - 3] != 'S') return 0;
        return 1;
    }
    private static int CheckUpRight(int row, int col)
    {
        if (row - 1 < 0 || col + 1 > maxCols || lines[row - 1][col + 1] != 'M') return 0;
        if (row - 2 < 0 || col + 2 > maxCols || lines[row - 2][col + 2] != 'A') return 0;
        if (row - 3 < 0 || col + 3 > maxCols || lines[row - 3][col + 3] != 'S') return 0;
        return 1;
    }
    private static int CheckDownRight(int row, int col)
    {
        if (row + 1 > maxRows || col + 1 > maxCols || lines[row + 1][col + 1] != 'M') return 0;
        if (row + 2 > maxRows || col + 2 > maxCols || lines[row + 2][col + 2] != 'A') return 0;
        if (row + 3 > maxRows || col + 3 > maxCols || lines[row + 3][col + 3] != 'S') return 0;
        return 1;
    }
    private static int CheckDownLeft(int row, int col)
    {
        if (row + 1 > maxRows || col - 1 < 0 || lines[row + 1][col - 1] != 'M') return 0;
        if (row + 2 > maxRows || col - 2 < 0 || lines[row + 2][col - 2] != 'A') return 0;
        if (row + 3 > maxRows || col - 3 < 0 || lines[row + 3][col - 3] != 'S') return 0;
        return 1;
    }
    
}
