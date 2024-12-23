namespace AdventOfCode2024._22;

public static class December22_PartTwo
{
    private static List<long> _numbers = new();
    private static long _secretNumber;
    private static long _number;
    private static Dictionary<string, int> _sequenceSums = new();

    public static long CalculateSumOfSecretNumbers()
    {
        long sum = 0;
        List<string> lines = File.ReadLines("../../../22/PuzzleInput.txt").ToList();
        
        for (int i = 0; i < lines.Count; i++)
        {
            _numbers.Add(long.Parse(lines[i]));
        }

        foreach (var number in _numbers)
        {
            var currentSums = new Dictionary<string, int>();
            var lastDiffs = new LinkedList<int>();

            _number = number;
            var previousLastDigit = GetLastDigit(_number);
            for (int i = 0; i < 2000; i++)
            {
                _number = Evolve(_number);
                var newLastDigit = GetLastDigit(_number);

                var diff = (int)(newLastDigit - previousLastDigit);
                lastDiffs.AddLast(diff);
                if (lastDiffs.Count == 4)
                {
                    var diffString = string.Join(",", lastDiffs.Select(d => d.ToString()));
                    if (!currentSums.ContainsKey(diffString))
                    {
                        currentSums[diffString] = newLastDigit;
                    }
                    lastDiffs.RemoveFirst();
                }

                previousLastDigit = newLastDigit;
            }

            foreach (var (key, value) in currentSums)
            {
                if (!_sequenceSums.ContainsKey(key))
                {
                    _sequenceSums[key] = value;
                }
                else
                {
                    _sequenceSums[key] += value;
                }
            }
        }

        return _sequenceSums.Values.Max();
    }
    
    
    private static long Mix(long a, long b) => a ^ b;
    private static long Prune(long a) => a % 16777216;
    private static int GetLastDigit(long a) => (int)(a % 10);
    
    private static long Evolve(long secretNumber)
    {
        var multiplied = secretNumber * 64;
        secretNumber = Mix(secretNumber, multiplied);
        secretNumber = Prune(secretNumber);

        var divided = secretNumber / 32;
        secretNumber = Mix(secretNumber, divided);
        secretNumber = Prune(secretNumber);

        multiplied = secretNumber * 2048;
        secretNumber = Mix(secretNumber, multiplied);
        secretNumber = Prune(secretNumber);

        return secretNumber;
    }

}