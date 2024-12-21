using AdventOfCode2024._2;

namespace AdventOfCode2024._7;

public static class December7_PartTwo
{
    private static List<Equation> _equations = new();

    public static long CalculateResults()
    {
        string content = File.ReadAllText("../../../7/PuzzleInput.txt");

        using (StringReader reader = new StringReader(content))
        {
            string input;
            while ((input = reader.ReadLine()) != null)
            {
                _equations.Add(new Equation
                {
                    Result = long.Parse(input.Split(": ")[0]),
                    Numbers = input.Split(": ")[1].Split(" ").Select(long.Parse).ToList()
                });
            }

            foreach (var equation in _equations)
            {
                IsSolvable(equation, equation.Numbers, 0);
            }
        }

        return _equations.Where(eq => eq.Solvable).Sum(eq => eq.Result);
    }


    private static bool IsSolvable(Equation equation, List<long> nextNumers, long tempResult)
    {
        // If tempresult exeeds result, escape
        if (tempResult > equation.Result)
        {
            return false;
        }

        // End of numbers to test
        if (!nextNumers.Any())
        {
            if (tempResult != equation.Result) return false;
            
            equation.Solvable = true;
            return true;
        }

        var number = nextNumers[0];
        var restOfNumers = nextNumers[1..];

        return IsSolvable(equation, restOfNumers, tempResult + number) || 
               IsSolvable(equation, restOfNumers, tempResult * number) ||
               IsSolvable(equation, restOfNumers, long.Parse($"{tempResult}{number}"));

    }
}

