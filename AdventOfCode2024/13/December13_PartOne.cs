
using System.Text.RegularExpressions;

namespace AdventOfCode2024._13;

public static class December13_PartOne
{
    
    private static List<ClawMachine> _clawMachines = new();
    public static long CalculateTokensToWinAllPrizes()
    {
        long sum = 0;
        List<string> inputLines = File.ReadLines("../../../13/PuzzleInput.txt").ToList();
        CreateClawMachines(inputLines);
        
        
        foreach (var clawMachine in _clawMachines)
        {
            var result = clawMachine.Solve();
            if (result.a != 0 && result.b != 0)
            {
                sum += result.a * 3 + result.b;
            }
        }
        return sum;
    }

    private static void CreateClawMachines(List<string> inputLines)
    {
        for (int line = 0; line < inputLines.Count; line += 4)
        {
            
            var buttonA = Regex.Matches(inputLines[line].Split(':')[1], "\\d*").Where(m => !string.IsNullOrEmpty(m.Value)).ToList();
            var buttonB = Regex.Matches(inputLines[line +1].Split(':')[1], "\\d*").Where(m => !string.IsNullOrEmpty(m.Value)).ToList();
            var prize = Regex.Matches(inputLines[line +2].Split(':')[1], "\\d*").Where(m => !string.IsNullOrEmpty(m.Value)).ToList();
            
            var newClawMachine = new ClawMachine
            {
                ButtonA = (long.Parse(buttonA[0].Value), long.Parse(buttonA[1].Value)),
                ButtonB = (long.Parse(buttonB[0].Value), long.Parse(buttonB[1].Value)),
                Prize = (long.Parse(prize[0].Value), long.Parse(prize[1].Value))
            };

            _clawMachines.Add(newClawMachine);
        }
    }
}


public class ClawMachine
{
    public (long X, long Y) ButtonA { get; set; }
    public (long X, long Y) ButtonB { get; set; }
    public (long X, long Y) Prize { get; set; }
    

    public (long a, long b) Solve()
    {
        // Equations
        // I    ButtonA.X + ButtonB.X = Prize.X
        // II   ButtonA.Y + ButtonB.Y = Prize.Y

        var equation1 = new double[] { ButtonA.X, ButtonB.X, Prize.X};
        var equation2 = new double[] { ButtonA.Y, ButtonB.Y, Prize.Y};

        var eqMultiplier1 = equation1[1];
        var eqMultiplier2 = equation2[1];
        
        equation1[0] *= eqMultiplier2;
        equation1[1] *= eqMultiplier2;
        equation1[2] *= eqMultiplier2;
        
        equation2[0] *= eqMultiplier1;
        equation2[1] *= eqMultiplier1;
        equation2[2] *= eqMultiplier1;

        var res = Math.Abs(equation1[2] - equation2[2]);
        var a = res / Math.Abs(equation1[0] - equation2[0]);

        var b = (equation1[2] - equation1[0] * a) / equation1[1];

        if (a % 1 != 0 || b % 1 != 0 )
        {
            return (0, 0);
        }

        return (long.Parse(a.ToString()), long.Parse(b.ToString()));
    }
}