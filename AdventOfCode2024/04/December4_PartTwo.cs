namespace AdventOfCode2024._04;

public class December4_PartTwo
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
                    if (letter == 'A')
                    {
                        sum += CheckDiagonals(row, col);
                    }
                    col++;
                }
                col = 0;
                row++;
            }
        }

        return sum;
    }

    private static int CheckDiagonals(int row, int col)
    {

        var diag1 = (row - 1 >= 0 && col - 1 >= 0 && lines[row - 1][col - 1] == 'M') &&
                    (row + 1 <= maxRows && col + 1 <= maxCols && lines[row + 1][col + 1] == 'S') ||
                    (row - 1 >= 0 && col - 1 >= 0 && lines[row - 1][col - 1] == 'S') &&
                    (row + 1 <= maxRows && col + 1 <= maxCols && lines[row + 1][col + 1] == 'M');

        var diag2 = (row - 1 >= 0 && col + 1 <= maxCols && lines[row - 1][col + 1] == 'M') &&
                    (row + 1 <= maxRows && col - 1 >= 0 && lines[row + 1][col - 1] == 'S') ||
                    (row - 1 >= 0 && col + 1 <= maxCols && lines[row - 1][col + 1] == 'S') &&
                    (row + 1 <= maxRows && col - 1 >= 0 && lines[row + 1][col - 1] == 'M');
        
        return diag1 && diag2 ? 1 : 0;
    }
    
}