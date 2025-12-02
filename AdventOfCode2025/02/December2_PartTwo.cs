using System.Text.RegularExpressions;

namespace AdventOfCode2025._02;

public class December2_PartTwo
{
    public static long CalculateSumOfInvalidIds()
    {
        var idRanges = File.ReadAllText("../../../02/PuzzleInput.txt").Split(',');
        List<long> invalidIds = new List<long>();

        foreach (var idRange in idRanges)
        {
            var start = long.Parse(idRange.Split('-')[0]);
            var end = long.Parse(idRange.Split('-')[1]);

            for (long id = start; id < end + 1; id++)
            {
                var match = Regex.Match(id.ToString(), @"^(\d+)\1+$");
                if (match.Success)
                {
                    invalidIds.Add(id);
                }
                
            }
        }
        return invalidIds.Sum(id => id);
    }
}