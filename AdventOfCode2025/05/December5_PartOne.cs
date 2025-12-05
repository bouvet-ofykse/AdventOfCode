
namespace AdventOfCode2025._05
{
    public class December5_PartOne
    {
        public static long CalculateNumberOfFreshIngredients()
        {
            long sum = 0;
            var lines = File.ReadLines("../../../05/PuzzleInput.txt").ToList();
            
            List<(long min, long max)> ranges = lines.Where(line => line.Contains("-")).Select(line => (long.Parse(line.Split("-")[0]), long.Parse(line.Split("-")[1]))).ToList();
            List<long> ids = lines.Where(line => !line.Contains("-") && !string.IsNullOrEmpty(line)).Select(long.Parse).ToList();

            foreach (var id in ids)
            {
                foreach (var range in ranges)
                {
                    if (id >= range.min && id <= range.max)
                    {
                        sum++;
                        break;
                    }
                }
            }
            
            return sum;
        }
    }
}
