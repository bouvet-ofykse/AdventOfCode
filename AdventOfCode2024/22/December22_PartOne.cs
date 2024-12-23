namespace AdventOfCode2024._22;

public static class December22_PartOne
{
    private static List<long> _numbers = new();
    private static long _secretNumber;

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
            _secretNumber = number;
            for (int i = 0; i < 2000; i++)
            {
                _secretNumber = Evolve(_secretNumber);
            }

            sum += _secretNumber;
        }

        return sum;
    }
    
    private static long Mix(long a, long b) => a ^ b;
    private static long Prune(long a) => a % 16777216;
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