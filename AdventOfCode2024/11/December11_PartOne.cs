using System.Diagnostics;

namespace AdventOfCode2024._11;

public static class December11_PartOne
{
    public static int SumNumberOfStonesAfterBlinks()
    {
        
        Stopwatch timer = new Stopwatch();
        List<string> stones = File.ReadAllText("../../../11/PuzzleInput.txt").Split(" ").ToList();

        for (int blink = 1; blink <= 25; blink++)
        {
            timer.Start();
            long currentAmountOfStones = stones.Count;
            for (int i = 0; i < currentAmountOfStones; i++)
            {
                if (stones[i] == "0")
                {
                    stones[i] = "1";
                }
                else if (stones[i].Length % 2 == 0)
                {
                    var newStone = stones[i].Substring(stones[i].Length / 2);
                    stones[i] = long.Parse(stones[i].Substring(0, stones[i].Length / 2)).ToString();
                    stones.Insert(i + 1, long.Parse(newStone).ToString());
                    currentAmountOfStones++;
                    i++;
                }
                else
                {
                    stones[i] = (long.Parse(stones[i]) * 2024).ToString();
                }
            }

            timer.Stop();
            Console.WriteLine($"Binkk {blink} finished in {timer.ElapsedMilliseconds} ms, number of stones: {stones.Count}");
        }
        timer.Stop();
        return stones.Count;
    }
}