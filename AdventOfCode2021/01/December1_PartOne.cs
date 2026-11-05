namespace AdventOfCode2021._01;

public class December1_PartOne
{
    public static long CalculateIncreasedMeasurements ()
    {
        var lines = File.ReadLines("../../../01/PuzzleInput.txt").ToArray();
        long sum = 0;
        
        for (int i = 1; i < lines.Count(); i++)
        {
            var current = Int32.Parse(lines[i]);
            var prev = Int32.Parse(lines[i-1]);

            if (current > prev)
            {
                Console.WriteLine("Increase: " + current + " (prev: " + prev + ")");
                sum++;
            }
        }

        return sum;
    }
}