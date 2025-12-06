using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2025._06
{
    public class December6_PartTwo
    {
        public static BigInteger CalculateTotalSumOfMathProblems()
        {
            BigInteger sum = 0;
            List<MathProblem> mathProblems = new List<MathProblem>();

            var lines = File.ReadLines("../../../06/PuzzleInput.txt").ToList();
            
            // Add extra column to make sure all problems are processed
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] += " ";
            }
            
            int height = lines.Count - 1;
            int width = lines[0].Length;
            var operators = Regex.Matches(lines.Last(), @"[\+\*]").Select(o => o.Value).ToList();
            int operatorsUsed = 0;
            
            char[,] map = new char[height, width];
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    map[r, c] = lines[r][c];
                }
            }

            var tempCols = new List<List<char>>();
            for (int col = 0; col < width; col++)
            {
                var tempCol = new List<char>();
                for(int row = 0; row < height; row++)
                {
                    tempCol.Add(map[row, col]);
                }
                
                if (tempCol.All(x => x == ' '))
                {
                    var mathProblem = new MathProblem();
                    
                    var stringOperand = "";
                    for (int i = 0; i < tempCols.Count; i++)
                    {
                        for (int j = 0; j < tempCols[i].Count; j++)
                        {
                            stringOperand += tempCols[i][j];
                        }
                        mathProblem.Operands.Add(long.Parse(stringOperand.Replace(" ", "")));
                        stringOperand = "";
                    }
                    mathProblem.Operator = operators[operatorsUsed];
                    mathProblems.Add(mathProblem);
                    operatorsUsed++;
                    tempCols.Clear();
                }
                else
                {
                    tempCols.Add(tempCol);
                }
            }

            foreach (var mathProblem in mathProblems)
            {
                var res = mathProblem.Solve();
                Console.WriteLine(res);
                sum += res;
            }
            
            return sum;
        }
    }
}
