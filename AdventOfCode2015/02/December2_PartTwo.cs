namespace AdventOfCode2015._02;

public class December2_PartTwo
{
    private static List<Present> _presents = new();

    public static long CalculateAmountOfRibbon()
    {
        List<string> lines = File.ReadLines("../../../02/PuzzleInput.txt").ToList();

        foreach (var line in lines)
        {
            var measurements = line.Split("x");
            _presents.Add(new Present(int.Parse(measurements[0]), int.Parse(measurements[1]),
                int.Parse(measurements[2])));
        }

        var sum = 0;

        // foreach (var present in _presents)
        // {
        //     sum += present.GetAmountOfRibbonForRequireed() + present.AmountOfRibbonForBow;
        // }
        //
        // return sum;
        
        return _presents.Sum(present => present.GetAmountOfRibbonForRequireed() + present.AmountOfRibbonForBow);
    }
}