using System.Diagnostics;

namespace AdventOfCode2024._11;

public static class December11_PartTwo
{

    public static long SumNumberOfStonesAfterBlinks()
    {
        Stopwatch timer = new Stopwatch();
        List<string> stones = File.ReadAllText("../../../11/PuzzleInput.txt").Split(" ").ToList();
        
        Dictionary<string, long> currentState = new ();
        stones.GroupBy(stone => stone).ToList().ForEach(stone => currentState.Add(stone.Key, stone.Count()));

        for (int blink = 1; blink <= 75; blink++)
        {
            timer.Start();
            var newState = new Dictionary<string, long>();
            foreach (var (number, count) in currentState)
            {
                ApplyRules(number, count, newState);
            }

            currentState = newState;            
            timer.Stop();
            Console.WriteLine($"Binkk {blink} finished in {timer.ElapsedMilliseconds} ms");
        }
        
        return currentState.Sum(n => n.Value);
    }
    
    private static void ApplyRules(string number, long count, Dictionary<string, long> next)
    {
        void SplitOrUpdateStone(string key, long value)
        {
            if (next.ContainsKey(key))
            {
                next[key] += value;
            }
            else
            {
                next.Add(key, value);
            }
        }

        if (number == "0")
        {
            SplitOrUpdateStone("1", count);
        }
        else if (number.Length % 2 == 0)
        {
            var newStone = long.Parse(number.Substring(number.Length / 2)).ToString();
            var currentStone = long.Parse(number.Substring(0, number.Length / 2)).ToString();

            SplitOrUpdateStone(currentStone, count);
            SplitOrUpdateStone(newStone, count);
        }
        else
        {
            var newStoneValue = long.Parse(number) * 2024;
            SplitOrUpdateStone(newStoneValue.ToString(), count);
        }
    }
}