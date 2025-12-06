namespace AdventOfCode2022._04;

public class December4_PartTwo
{
    public static long CalculateReducedAssignmentPairs()
    {
        long sum = 0;
        // List<string> lines = File.ReadLines("../../../04/TestInput.txt").ToList();
        List<string> lines = File.ReadLines("../../../04/PuzzleInput.txt").ToList();

        foreach (var line in lines)
        {
            (long start, long end) firstElf = (long.Parse(line.Split(",")[0].Split("-")[0]), long.Parse(line.Split(",")[0].Split("-")[1]));
            (long start, long end) secondElf = (long.Parse(line.Split(",")[1].Split("-")[0]), long.Parse(line.Split(",")[1].Split("-")[1]));

            if ((firstElf.start >= secondElf.start && firstElf.start <= secondElf.end )||
                (secondElf.start >= firstElf.start && secondElf.start <= firstElf.end))
            {
                Console.WriteLine(line);
                sum++;
            }
        }

        return sum;
    }
}