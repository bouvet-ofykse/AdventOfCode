using System.Text.RegularExpressions;

namespace AdventOfCode2021._02;

public class December2_PartTwo
{
    public static long CalclatePosition()
    {
        var lines = File.ReadLines("../../../02/PuzzleInput.txt").ToArray();
        long position = 0;
        long depth = 0;
        long aim = 0;

        foreach (var line in lines)
        {
            var amount = Regex.Match(line, @"\d+").Value;
            if (line.Contains("forward"))
            {
                position += long.Parse(amount);
                depth += aim * long.Parse(amount);
            }
            if (line.Contains("up"))
            {
                aim -= long.Parse(amount);
            }
            if (line.Contains("down"))
            {
                aim += long.Parse(amount);
            }
        }
        
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Depth: {depth}");
        Console.WriteLine($"Aim: {aim}");
        return position * depth;
    }
}