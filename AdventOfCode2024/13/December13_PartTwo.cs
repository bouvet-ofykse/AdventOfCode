using System.Text.RegularExpressions;

namespace AdventOfCode2024._13;

public static class December13_PartTwo
{
    
    private static List<ClawMachine> _clawMachines = new();
    public static long CalculateTokensToWinAllPrizes()
    {
        int counter = 0;
        long sum = 0;
        List<string> inputLines = File.ReadLines("../../../13/PuzzleInput.txt").ToList();
        CreateClawMachines(inputLines);
        
        
        foreach (var clawMachine in _clawMachines)
        {
            var result = clawMachine.Solve();
            counter++;
            if (result.a != 0 && result.b != 0)
            {
                Console.WriteLine($"Equation {counter} is solvable");
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
                Prize = (long.Parse(prize[0].Value) + 10000000000000, long.Parse(prize[1].Value) + 10000000000000)
            };

            _clawMachines.Add(newClawMachine);
        }
    }
}