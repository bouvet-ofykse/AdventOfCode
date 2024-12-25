namespace AdventOfCode2024._25;

public static class December25_PartOne
{
    private static List<List<int>> _keys = new();
    private static List<List<int>> _locks = new();

    public static long CalculateUniqueLockKeyPairs()
    {
        long sum = 0;
        List<string> lines = File.ReadAllLines("../../../25/PuzzleInput.txt").ToList();
        
        
        MapKeysAndLocks(lines);

        foreach (var currentKey in _keys)
        {
            foreach (var currentLock in _locks)
            {
                var tempResult = new List<int>();

                for (int index = 0; index < currentLock.Count; index++)
                {
                    tempResult.Add(currentKey[index] + currentLock[index]);
                }
                
                if (!tempResult.Any(number => number > 5))
                {
                    sum++;
                }
            }
        }

        return sum;
    }

    private static void MapKeysAndLocks(List<string> lines)
    {
        for (int lineNumber = 0; lineNumber < lines.Count; lineNumber += 8)
        {
            var currentLines = lines.Slice(lineNumber, 7).ToList();
            bool isLock = currentLines.First().All(character => character == '#');

            int[] numbers = new int[5];
            for (int y = 0; y < currentLines.Count; y++)
            {
                for (int x = 0; x < currentLines[y].Length; x++)
                {
                    if (currentLines[y][x] == '#')
                    {
                        numbers[x]++;
                    }
                }
            }

            if (isLock)
            {
                _locks.Add(numbers.Select(number => number - 1).ToList());
            }
            else
            {
                _keys.Add(numbers.Select(number => number - 1).ToList());
            }
            
        }
    }
}