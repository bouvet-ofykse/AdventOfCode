using System.Text.RegularExpressions;

namespace AdventOfCode2021._02;

public class December2_PartOne
{
    public static long CalclatePosition()
    {
        var lines = File.ReadLines("../../../02/PuzzleInput.txt").ToArray();
        long position = 0;
        long depth = 0;

        foreach (var line in lines)
        {
            var amount = Regex.Match(line, @"\d+").Value;
            if (line.Contains("forward"))
            {
                position += long.Parse(amount);
            }
            if (line.Contains("up"))
            {
                depth -= long.Parse(amount);
            }
            if (line.Contains("down"))
            {
                depth += long.Parse(amount);
            }
        }
        
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Depth: {depth}");
        return position * depth;
    }
}