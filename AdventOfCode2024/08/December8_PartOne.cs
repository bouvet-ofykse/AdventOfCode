using AdventOfCode2024.Tools;

namespace AdventOfCode2024._08;

public static class December8_PartOne
{
    private static int _mapWidth;
    private static int _mapHeight;

    private static Dictionary<char, List<Point>> _antennas = new();

    public static int CalculateUniqeLocationsOfAntinode()
    {
        var lines = File.ReadLines("../../../8/PuzzleInput.txt").ToList();

        _mapWidth = lines[0].Length;
        _mapHeight = lines.Count;
        
        var grid = new char[_mapWidth, _mapHeight];
        for (var y = 0; y < _mapHeight; y++)
        {
            var line = lines[y];
            for (var x = 0; x < _mapWidth; x++)
            {
                var character = line[x];
                grid[x, y] = character;

                if (character != '.')
                {
                    if (!_antennas.TryGetValue(character, out var pointList))
                    {
                        pointList = new List<Point>();
                        _antennas[character] = pointList;
                    }

                    pointList.Add((x, y));
                }
            }
        }

        HashSet<Point> antinodes = new();

        foreach (var antennaType in _antennas)
        {
            var points = antennaType.Value;
            for (var antenna1 = 0; antenna1 < points.Count; antenna1++)
            {
                for (int antenna2 = antenna1 + 1; antenna2 < points.Count; antenna2++)
                {
                    var diff = points[antenna2] - points[antenna1];

                    antinodes.Add(points[antenna1] - diff);
                    antinodes.Add(points[antenna2] + diff);
                }
            }
        }

        return antinodes.Where(IsInBounds).Count();
    }
    
    private static bool IsInBounds(Point p)
    {
        return p.X >= 0 && p.X < _mapWidth && p.Y >= 0 && p.Y < _mapHeight;
    }
    
}
