namespace AdventOfCode2024._19;

public static class December19_PartTwo
{
    private static List<string> _availableTowelPatterns = new();
    private static List<string> _designs = new();
    private static Dictionary<string, long> _resultsMemory = new();

    public static long CalculateNumberOfPossibleDesigns()
    {
        List<string> lines = File.ReadLines("../../../19/PuzzleInput.txt").ToList();
        long sum = 0;
        var counter = 0;

        _availableTowelPatterns = lines.First().Split(", ").ToList();
        _designs = lines.Skip(1).Where(line => line.Any()).ToList();

        foreach (var design in _designs)
        {
            sum += CountWaysToFormDesign(design);

            counter++;
            Console.WriteLine($"Done checking {counter} / {_designs.Count}");
        }

        return sum;
    }

    private static long CountWaysToFormDesign(string design)
    {
        if (string.IsNullOrEmpty(design))
        {
            return 1;
        }

        if (_resultsMemory.ContainsKey(design))
        {
            return _resultsMemory[design];
        }

        long counter = 0;

        foreach (var towel in _availableTowelPatterns)
        {
            if (design.StartsWith(towel))
            {
                string remainingDesign = design.Substring(towel.Length);
                counter += CountWaysToFormDesign(remainingDesign);
            }
        }

        _resultsMemory[design] = counter;
        return counter;
    }
}