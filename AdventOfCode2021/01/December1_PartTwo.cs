namespace AdventOfCode2021._01;

public class December1_PartTwo
{
    public static long CalculateIncreasedMeasurementsSlidingWindow ()
    {
        var lines = File.ReadLines("../../../01/PuzzleInput.txt").ToArray();
        long sum = 0;
        
        for (int i = 3; i < lines.Count(); i++)
        {
            var current1 = Int32.Parse(lines[i]);
            var current2 = Int32.Parse(lines[i-1]);
            var current3 = Int32.Parse(lines[i-2]);
            var sumCurrent = current1 + current2 + current3;
            var prev1 = Int32.Parse(lines[i-3]);
            var prev2 = Int32.Parse(lines[i-2]);
            var prev3 = Int32.Parse(lines[i-1]);
            var sumPrev = prev1 + prev2 + prev3;

            if (sumCurrent > sumPrev)
            {
                Console.WriteLine($"Current: ({current1} + {current2} + {current3} = {sumCurrent}) > Previous: ({prev1} + {prev2} + {prev3} = {sumPrev})");
                sum++;
            }
        }

        return sum;
    }
}