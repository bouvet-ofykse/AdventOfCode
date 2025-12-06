
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2025._06
{
    public class December6_PartOne
    {
        public static BigInteger CalculateTotalSumOfMathProblems()
        {
            BigInteger sum = 0;
            List<MathProblem> mathProblems = new List<MathProblem>();
            var lines = File.ReadLines("../../../06/PuzzleInput.txt").ToList();
            // var lines = File.ReadLines("../../../06/TestInput.txt").ToList();

            var operandLines = new List<List<string>>();
            var operatorLine = new List<string>();

            foreach (var line in lines)
            {
                
                var temp = Regex.Matches(line, @"\d+");
                if (temp.Count > 0)
                {
                    operandLines.Add(temp.Select(m => m.Value).ToList());
                }
                else
                {
                    operatorLine = Regex.Matches(line, @"[\+\*]").Select(o => o.Value).ToList();
                }
            }

            for (int i = 0; i < operandLines[0].Count; i++)
            {
                var temmp = new MathProblem();
                foreach (var line in operandLines)
                {
                    temmp.Operands.Add(long.Parse(line[i]));   
                }
                temmp.Operator = operatorLine[i];
                mathProblems.Add(temmp);
            }
            
            foreach (var problem in mathProblems)
            {
                sum +=  problem.Solve();
            }
            
            return sum;
        }
    }
}
