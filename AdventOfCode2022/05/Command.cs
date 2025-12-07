using System.Text.RegularExpressions;

namespace AdventOfCode2022._05;

public class Command
{
    public int From { get; set; }
    public int To { get; set; }
    public int Amount { get; set; }
    
    
    public static List<Command> ParseCommands(List<string> lines)
    {
        List<Command> commands = new ();

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"move (\d+) from (\d+) to (\d+)");
            if (matches.Count > 0)
            {
                var amount = int.Parse(matches[0].Groups[1].Value);
                var from = int.Parse(matches[0].Groups[2].Value);
                var to = int.Parse(matches[0].Groups[3].Value);

                commands.Add(new Command
                {
                    Amount = amount,
                    From = from,
                    To = to
                });
            }
        }

        return commands;
    }
}