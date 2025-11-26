using System.Text.RegularExpressions;

namespace AdventOfCode2015._06;

public class December6_PartOne
{
    public static long CalculateNumberOfLightsLit()
    {
        List<Action> actions = [];
        var lights = new Dictionary<(int y, int x), bool>();
        
        var lines = File.ReadLines("../../../06/PuzzleInput.txt").ToList();

        actions.AddRange(lines.Select(CreateAction));

        for (var y = 0; y <= 999; y++)
        {
            for (var x = 0; x <= 999; x++)
            {
                lights.Add((y, x), false);
            }
        }

        foreach (var action in actions)
        {
            PerformAction(action, lights);
        }
        
        return lights.Sum(light => light.Value ? 1 : 0);
    }

    private static void PerformAction(Action action, Dictionary<(int y, int x), bool> lights)
    {
        for (var y = action.From.y; y <= action.To.y; y++)
        {
            for (var x = action.From.x; x <= action.To.x; x++)
            {
                lights[(y, x)] = action.Intstruction switch
                {
                    Intstruction.TurnOn => true,
                    Intstruction.TurnOff => false,
                    Intstruction.Toggle => !lights[(y, x)],
                    _ => lights[(y, x)]
                };
            }
        }
    }

    private static Action CreateAction(string line)
    {
        var matches = Regex.Matches(line, @"\d{1,3},\d{1,3}");

        (int x, int y) Parse(string s)
        {
            var parts = s.Split(',');
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        var from = Parse(matches[0].Value);
        var to = Parse(matches[1].Value);

        if (line.StartsWith("turn on"))
        {
            return new Action(from, to, Intstruction.TurnOn);
        }
        else if (line.StartsWith("turn off"))
        {
            return new Action(from, to, Intstruction.TurnOff);
        }
        else // toggle
        {
            return new Action(from, to, Intstruction.Toggle);
        }
    }
}

class Action
{
    public Action((int x, int y) from, (int x, int y) to, Intstruction intstruction)
    {
        From = from;
        To = to;
        Intstruction = intstruction;
    }
    public (int x, int y) From { get; set; }
    public (int x, int y) To { get; set; }
    public Intstruction Intstruction { get; set; }
}

public enum Intstruction
{
    TurnOn,
    TurnOff,
    Toggle
}