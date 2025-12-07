
namespace AdventOfCode2022._06;

public class December6_PartOne
{
    public static long CalculateStartOfPacketMarker()
    {
        long sum = 0;
        string line = File.ReadLines("../../../06/PuzzleInput.txt").ToList().First();

        Queue<char> queue = new Queue<char>();
        
        queue.Enqueue(line[0]);
        queue.Enqueue(line[1]);
        queue.Enqueue(line[2]);
        queue.Enqueue(line[3]);
        for (int i = 4; i < line.Length; i++)
        {
            if (queue.Distinct().Count() == 4)
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