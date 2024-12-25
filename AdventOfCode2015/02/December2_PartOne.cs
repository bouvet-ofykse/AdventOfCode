namespace AdventOfCode2015._02;

public class December2_PartOne
{
    private static List<Present> _presents = new();

    public static long CalculateAmountOfWrappingPaper()
    {
        List<string> lines = File.ReadLines("../../../02/PuzzleInput.txt").ToList();

        foreach (var line in lines)
        {
            var measurements = line.Split("x");
            _presents.Add(new Present(int.Parse(measurements[0]), int.Parse(measurements[1]),
                int.Parse(measurements[2])));
        }

        return _presents.Sum(present => present.SurfaceArea + present.SmallestSideArea);
    }
}

public class Present
{
    private int Length { get; set; }
    private int Width { get; set; }
    private int Height { get; set; }

    public int FirstSide => Length * Width;
    public int SecondSide => Width * Height;
    public int ThirdSide => Height * Length;
    
    public int SurfaceArea => (2 * FirstSide) + (2 * SecondSide) + (2 * ThirdSide);
    public int SmallestSideArea => Math.Min(FirstSide, Math.Min(SecondSide, ThirdSide));
    public int AmountOfRibbonForBow => Length * Width * Height;

    public int GetAmountOfRibbonForRequireed()
    {
        var dimensions = new List<int> { Length, Width, Height}.ToArray();
        var dimensionsOrdered = dimensions.Order().ToList();
        return dimensionsOrdered[0] + dimensionsOrdered[0] + dimensionsOrdered[1] + dimensionsOrdered[1];
    }

    public Present(int length, int width, int height)
    {
        Length = length;
        Width = width;
        Height = height;
    }
}