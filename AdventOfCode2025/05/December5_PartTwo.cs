
using System.Numerics;

namespace AdventOfCode2025._05
{
    public class December5_PartTwo
    {
        public static BigInteger CalculateNumberOfFreshIngredientIds()
        {
            BigInteger sum = 0;
            var lines = File.ReadLines("../../../05/PuzzleInput.txt").ToList();
           
            List<(long min, long max)> ranges = lines.Where(line => line.Contains("-")).Select(line => (long.Parse(line.Split("-")[0]), long.Parse(line.Split("-")[1]))).ToList();
            List<(long min, long max)> mergedRanges = new List<(long min, long max)>();
            
            
            ranges.Sort((a, b) => a.min.CompareTo(b.min));
            
            var current = ranges[0];

            for (int i = 1; i < ranges.Count; i++)
            {
                var next = ranges[i];

                if (next.min <= current.max + 1)
                {
                    current.max = Math.Max(current.max, next.max);
                }
                else
                {
                    mergedRanges.Add(current);
                    current = next;
                }
            }
            mergedRanges.Add(current);
            
            foreach (var r in mergedRanges)
            {
                sum += (BigInteger) r.max - r.min + 1;
            }
            
            return sum;
        }
    }
}
