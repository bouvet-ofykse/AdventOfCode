namespace AdventOfCode2022._03;

public class December3_PartTwo
{
    public static long CalculateSumOfPriorities()
    {
        long sum = 0;
        List<string> lines = File.ReadLines("../../../03/PuzzleInput.txt").ToList();

        List<List<string>> groups = new ();

        for (int i = 0; i < lines.Count; i += 3)
        {
            groups.Add(new List<string>{lines[i], lines[i + 1], lines[i + 2]});
        }

        foreach (List<string> group in groups)
        {
            var priority = group[0].Intersect(group[1]).Intersect(group[2]);
            sum += LetterToNumber(priority.First());
        }

        return sum;
    }
    
    private static int LetterToNumber(char c)
    {
        return c == char.ToLower(c) ? c - 'a' + 1 : c - 'A' + 27;
    }
}