namespace AdventOfCode2025._01;

public class December1_PartOne
{
    public static int CalculatePassword()
    {
        IEnumerable<string> lines = File.ReadLines("../../../01/PuzzleInput.txt");
        int sum = 0;
        int dial = 50;

        foreach (var line in lines)
        {
            var code = int.Parse(line.Substring(1));

            if (line.StartsWith('R'))
            {
                dial = (dial + code) % 100;
            }
            else
            {
                dial = (dial - code + 100) % 100;
            }

            if (dial == 0)
            {
                sum++;
            }

        }

        return sum;
    }
}