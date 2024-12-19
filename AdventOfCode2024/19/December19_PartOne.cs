namespace AdventOfCode2024._19;

public static class December19_PartOne
{
    private static List<string> _availableTowelPatterns = new();
    private static List<string> _designs = new();
    private static Dictionary<string, bool> _resultsMemory = new();

    public static int CalculateNumberOfPossibleDesigns()
    {
        List<string> lines = File.ReadLines("../../../19/PuzzleInput.txt").ToList();
        var sum = 0;
        var counter = 0;

        _availableTowelPatterns = lines.First().Split(", ").ToList();
        _designs = lines.Skip(1).Where(line => line.Any()).ToList();
        
        foreach (var design in _designs)
        {
            if (IsDesignPossible(design))
            {
                sum++;
            }

            counter++;
            Console.WriteLine($"Done checking {counter} / {_designs.Count}");
        }

        return sum;
    }

    private static bool IsDesignPossible(string design)
    {
        
        if (string.IsNullOrEmpty(design))
        {
            return true;
        }
        
        if (_resultsMemory.ContainsKey(design))
        {
            return _resultsMemory[design];
        }
        
        foreach (var towel in _availableTowelPatterns)
        {
            if (design.StartsWith(towel))
            {
                string remainingDesign = design.Substring(towel.Length);
                if (IsDesignPossible(remainingDesign))
                {
                    _resultsMemory[design] = true;
                    return true;
                }
            }
        }
        
        _resultsMemory[design] = false;
        return false;
    }
}