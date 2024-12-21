using System.Text.RegularExpressions;

namespace AdventOfCode2024._2;

public static class December3_PartOne
{
    public static int CalculateResults()
    {
        string content = File.ReadAllText("../../../3/PuzzleInput.txt");
        int sum = 0;

        using (StringReader reader = new StringReader(content))
        {
            var input = reader.ReadToEnd();

            var mulExpressions = Regex.Matches(input, @"mul\([0-9]{0,3},[0-9]{0,3}\)");
            foreach (Match expression in mulExpressions)
            {
                sum += CalculateExpression(expression);
            }
        }
        return sum;
    }
    
    private static int CalculateExpression(Match expression)
    {
        var factors = Regex.Matches(expression.ToString(), @"[0-9]{1,3},[0-9]{1,3}").SingleOrDefault().ToString().Split(",");

        var firstFactor = int.Parse(factors[0]);
        var secondFactor = int.Parse(factors[1]);

        return firstFactor * secondFactor;
    }
}