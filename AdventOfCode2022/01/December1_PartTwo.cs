namespace AdventOfCode2022._01;

public class December1_PartTwo
{
    public static long CalculateCalories()
    {
        IEnumerable<string> lines = File.ReadLines("../../../01/PuzzleInput.txt");
        List<long> calories = new ();

        long tempSum = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(tempSum);
                tempSum = 0;
                continue;
            }
            tempSum += long.Parse(line);
        }
        
        return calories.OrderByDescending(c => c).ToList().Take(3).Sum();
    }
}