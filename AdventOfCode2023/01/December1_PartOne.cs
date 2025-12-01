using System.Text.RegularExpressions;

namespace AdventOfCode2023._01;

public class December1_PartOne
{
    public static long CalibrateDocument()
    {
        var lines = File.ReadLines("../../../01/PuzzleInput.txt").ToList();
        long sum = 0;

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"\d");
            sum += long.Parse($"{matches.First()}{matches.Last()}");
        }
        
        return sum;
    }
}