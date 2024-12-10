using AdventOfCode2024.Tools;

namespace AdventOfCode2024._10;

public static class December10_PartOne
{
    private static int _mapWidth;
    private static int _mapHeight;

    public static string CalculateScoresOfAllTrailheads()
    {
        List<string> lines = File.ReadLines("../../../10/PuzzleInput.txt").ToList();

        _mapWidth = lines[0].Length;
        _mapHeight = lines.Count;

        List<Point> starts = [];

        var map = new char[lines[0].Length, lines.Count];

        for (var y = 0; y < lines.Count; y++)
        {
            for (var x = 0; x < lines[0].Length; x++)
            {
                map[x, y] = lines[y][x];
            }
        }

        starts = map.GetPoints().Where(p => map[p.X, p.Y] == '0').ToList();
        var trailheads = FindTrails(map, starts);

        return trailheads.Values.Sum(x => x.Distinct().Count()).ToString();
    }

    private static Dictionary<Point, IEnumerable<Point>> FindTrails(char[,] map, List<Point> starts)
    {
        var trailheads = new Dictionary<Point, IEnumerable<Point>>();

        foreach (var trailhead in starts)
        {
            trailheads.Add(trailhead, new List<Point>() { trailhead });
        }

        for (var i = 1; i <= 9; i++)
        {
            foreach (var th in trailheads.Keys)
            {
                var newTrails = new List<Point>();

                foreach (var trail in trailheads[th])
                {
                    foreach (var neighbor in trail.GetNeighbors())
                    {
                        if (IsValidPoint(neighbor) && map[neighbor.X, neighbor.Y] == i.ToString()[0])
                        {
                            newTrails.Add(neighbor);
                        }
                    }
                }
                trailheads[th] = newTrails;
            }
        }
        return trailheads;
    }

    private static IEnumerable<Point> GetNeighbors(this Point point)
    {
        var adjacentPoints = new List<Point>();

        adjacentPoints.Add(new Point(point.X - 1, point.Y));
        adjacentPoints.Add(new Point(point.X + 1, point.Y));
        adjacentPoints.Add(new Point(point.X, point.Y + 1));
        adjacentPoints.Add(new Point(point.X, point.Y - 1));
        return adjacentPoints;
    }

    private static IEnumerable<Point> GetPoints<T>(this T[,] grid)
    {
        for (var y = 0; y < grid.GetLength(1); y++)
        {
            for (var x = 0; x < grid.GetLength(0); x++)
            {
                yield return new Point(x, y);
            }
        }
    }
    
    private static bool IsValidPoint(Point point)
    {
        if (point.X >= 0 && point.X < _mapWidth)
        {
            if (point.Y >= 0 && point.Y < _mapHeight)
            {
                return true;
            }
        }
        return false;
    }
}