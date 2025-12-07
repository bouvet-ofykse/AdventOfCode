
namespace AdventOfCode2022._06;

public class December6_PartTwo
{
    public static long CalculateStartOfMessageMarker()
    {
        long sum = 0;
        string line = File.ReadLines("../../../06/PuzzleInput.txt").ToList().First();

        Queue<char> queue = new Queue<char>();

        for (int i = 0; i < 14; i++)
        {
            queue.Enqueue(line[i]);
        }
        for (int i = 14; i < line.Length; i++)
        {
            if (queue.Distinct().Count() == 14)
            {
                sum = i;
                break;
            }
            queue.Dequeue();
            queue.Enqueue(line[i]);
        }
        return sum;
    }
}
