namespace AdventOfCode2022._04;

public class December4_PartOne
{
    public static long CalculateReducedAssignmentPairs()
    {
        long sum = 0;
        List<string> lines = File.ReadLines("../../../04/PuzzleInput.txt").ToList();

        foreach (var line in lines)
        {
            var firstElfStart = long.Parse(line.Split(",")[0].Split("-")[0]);
            var firstElfEnd = long.Parse(line.Split(",")[0].Split("-")[1]);
            var secondElfStart = long.Parse(line.Split(",")[1].Split("-")[0]);
            var secondElfEnd = long.Parse(line.Split(",")[1].Split("-")[1]);
            
            if ((firstElfStart >= secondElfStart && firstElfEnd <= secondElfEnd) ||
                (secondElfStart >= firstElfStart && secondElfEnd <= firstElfEnd))
            {
                sum++;
            }
        }

        return sum;
    }
    

}