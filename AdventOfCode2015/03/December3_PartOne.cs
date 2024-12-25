using System.Drawing;

namespace AdventOfCode2015._03;

public class December3_PartOne
{
    private static Dictionary<Point, int> _housesVisited = new();

    public static long CalculateHousesThatReceivesGifts()
    {
        string directions = File.ReadAllText("../../../03/PuzzleInput.txt");
        var currentPosition = new Point(0, 0);
        _housesVisited.Add(currentPosition, 1);

        foreach (var direction in directions)
        {
            switch (direction)
            {
                case '^':
                    currentPosition = new Point(currentPosition.X, currentPosition.Y + 1);
                    break;
                case '>':
                    currentPosition = new Point(currentPosition.X + 1, currentPosition.Y);
                    break;
                case 'v':
                    currentPosition = new Point(currentPosition.X, currentPosition.Y - 1);
                    break;
                case '<':
                    currentPosition = new Point(currentPosition.X - 1, currentPosition.Y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }
            // Add or update dictionary
            if (_housesVisited.ContainsKey(currentPosition))
            {
                _housesVisited[currentPosition] = _housesVisited[currentPosition]++;
            }
            else
            {
                _housesVisited.Add(currentPosition, 1);
            }
        }

        return _housesVisited.Count;
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