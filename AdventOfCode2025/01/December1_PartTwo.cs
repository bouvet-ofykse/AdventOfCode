namespace AdventOfCode2025._01;

public class December1_PartTwo
{
    public static int CalculatePassword()
    {
        IEnumerable<string> lines = File.ReadLines("../../../01/PuzzleInput.txt");
        int sum = 0;
        int dial = 50;

        foreach (var line in lines)
        {
            int code = int.Parse(line.Substring(1));

            for (int i = 0; i < code; i++)
            {
                if (line.StartsWith('R'))
                {
                    dial = (dial + 1) % 100;
                }
                else
                {
                    dial = (dial - 1 + 100) % 100;
                }
                if (dial == 0)
                {
                    sum++;
                }
            }

        }
        return sum;
    }
}