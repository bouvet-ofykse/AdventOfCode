using AdventOfCode2024.Tools;

namespace AdventOfCode2024._14;

public static class December14
{
    private static List<List<char>> _map = new();

    private static List<Robot> _robots = new();
    public static int MapHeight => _map.Count;
    public static int MapWidth => _map[0].Count;


    public static int CalculateBathroomSaftyFactor()
    {
        List<string> lines = File.ReadLines("../../../14/PuzzleInput.txt").ToList();
        var outputFilePath = "../../../14/output.txt";

        AddRobotsToList(lines);
        CreateMap(103, 101);
        PlaceRobotsInStartingPosition();
        
        File.WriteAllText(outputFilePath, string.Empty);

        PrintMapToFile(outputFilePath, 0);
        for (int seconds = 1; seconds <= 10000; seconds++)
        {
            MoveRobots();
            Console.WriteLine($"After {seconds}:");
            PrintMapToFile(outputFilePath, seconds);
        }

        List<List<List<char>>> quadrants = SplitIntoQuadrants();

        return quadrants.Select(SumRobotInQuadrant).ToList().Aggregate((a, x) => a * x);
    }

    private static int SumRobotInQuadrant(List<List<char>> quadrant)
    {
        int sum = 0;
        foreach (var row in quadrant)
        {
            foreach (var character in row)
            {
                if (character != '.')
                {
                    sum += int.Parse(character.ToString());
                }
            }
        }
        return sum;
    }

    private static List<List<List<char>>> SplitIntoQuadrants()
    {
        var quadrantHeight = MapHeight / 2;
        var quadrantWidth = MapWidth / 2;

        var res = new List<List<List<char>>>();

        var firstQuadrant = new List<List<char>>();
        var secondQuadrant = new List<List<char>>();
        var thirdQuadrant = new List<List<char>>();
        var fourthQuadrant = new List<List<char>>();

        foreach (var row in _map.Slice(0, quadrantHeight))
        {
            firstQuadrant.Add(row.Slice(0, quadrantWidth).ToList());
            secondQuadrant.Add(row.Slice(quadrantWidth + 1, quadrantWidth).ToList());
        }

        foreach (var row in _map.Slice(quadrantHeight + 1, quadrantHeight))
        {
            thirdQuadrant.Add(row.Slice(0, quadrantWidth).ToList());
            fourthQuadrant.Add(row.Slice(quadrantWidth + 1, quadrantWidth).ToList());
        }

        res.Add(firstQuadrant);
        res.Add(secondQuadrant);
        res.Add(thirdQuadrant);
        res.Add(fourthQuadrant);

        return res;
    }

    private static void MoveRobots()
    {
        foreach (var robot in _robots)
        {
            RemoveRobotFromTile(robot.Position.Y, robot.Position.X);

            robot.Move();

            AddRobotToTile(robot.Position.Y, robot.Position.X);
        }
    }

    private static void AddRobotToTile(int y, int x)
    {
        var tileChar = _map[y][x];
        if (tileChar != '.')
        {
            _map[y][x] = (int.Parse(tileChar.ToString()) + 1).ToString()[0];
        }
        else
        {
            _map[y][x] = '1';
        }
    }

    private static void RemoveRobotFromTile(int y, int x)
    {
        var currentTileChar = _map[y][x];
        if (currentTileChar == '1')
        {
            _map[y][x] = '.';
        }
        else
        {
            _map[y][x] = (int.Parse(currentTileChar.ToString()) - 1).ToString()[0];
        }
    }

    private static void PlaceRobotsInStartingPosition()
    {
        foreach (var robot in _robots)
        {
            AddRobotToTile(robot.Position.Y, robot.Position.X);
        }
    }

    public static bool IsOutOfBounds(int y, int x)
    {
        if (y <= 0 || y >= MapHeight) return true;
        if (x <= 0 || x >= MapWidth) return true;

        return false;
    }


    private static void PrintMap()
    {
        Console.WriteLine("***********");
        string mapLine = "";
        foreach (var line in _map)
        {
            foreach (var position in line)
            {
                mapLine += position;
            }

            Console.WriteLine(mapLine);
            mapLine = "";
        }

        Console.WriteLine("***********\n");
    }
    private static void PrintMapToFile(string path, int seconds)
    {
        List<string> content = new ();
        content.Add($"After {seconds}: ");
        string mapLine = "";
        foreach (var line in _map)
        {
            foreach (var position in line)
            {
                mapLine += position;
            }

            content.Add(mapLine);
            mapLine = "";
        }

        content.Add("\n");
        
        File.AppendAllLines(path, content);
    }

    private static void CreateMap(int height, int width)
    {
        for (int y = 0; y < height; y++)
        {
            var newLine = new List<char>();
            for (int x = 0; x < width; x++)
            {
                newLine.Add('.');
            }

            _map.Add(newLine);
        }
    }

    private static void AddRobotsToList(List<string> lines)
    {
        foreach (var line in lines)
        {
            var position = line.Split(" ")[0].Split("=")[1];
            var velocity = line.Split(" ")[1].Split("=")[1];

            var newRobot = new Robot
            {
                Position = new Point(int.Parse(position.Split(",")[0]), int.Parse(position.Split(",")[1])),
                Velocity = new Point(int.Parse(velocity.Split(",")[0]), int.Parse(velocity.Split(",")[1]))
            };
            _robots.Add(newRobot);
        }
    }
}

public class Robot
{
    public Point Position { get; set; }
    public Point Velocity { get; set; }

    public void Move()
    {
        var newPosition = Position + Velocity;

        if (December14.IsOutOfBounds(newPosition.Y, newPosition.X))
        {
            Position = Teleport(newPosition);
        }
        else
        {
            Position += Velocity;
        }
    }

    private Point Teleport(Point invalidPosition)
    {
        var newPosition = invalidPosition;
        // Teleport from bottom to top
        if (invalidPosition.Y > December14.MapHeight - 1)
        {
            newPosition.Y = invalidPosition.Y - December14.MapHeight;
        }

        // Teleport from top to bottom
        if (invalidPosition.Y < 0)
        {
            newPosition.Y = invalidPosition.Y + December14.MapHeight;
        }

        // Teleport right to left
        if (invalidPosition.X > December14.MapWidth - 1)
        {
            newPosition.X = invalidPosition.X - December14.MapWidth;
        }

        // Teleport left bottom to right
        if (invalidPosition.X < 0)
        {
            newPosition.X = invalidPosition.X + December14.MapWidth;
        }

        return newPosition;
    }
}