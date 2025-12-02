using System;

namespace AdventOfCode2023._03
{
    public class December3_PartTwo
    {
        public static long CalculateGearRatios()
        {
            long sum = 0;
            var lines = File.ReadLines("../../../03/PuzzleInput.txt").ToList();
            int height = lines.Count;
            int width = lines[0].Length;

            char[,] map = new char[height, width];
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                    map[r, c] = lines[r][c];

            // Direction vectors for all 8 directions
            int[] dircol = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dirrow = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Liste over alle tall i kartet, med koordinatene deres
            var numbers = new List<(int value, List<(int row, int col)> coords)>();

            // Først: finn ALLE tallene og deres koordinater
            for (int row = 0; row < height; row++)
            {
                int col = 0;
                while (col < width)
                {
                    if (!char.IsDigit(map[row, col]))
                    {
                        col++;
                        continue;
                    }

                    int start = col;
                    List<(int row, int col)> coords = new();

                    while (col < width && char.IsDigit(map[row, col]))
                    {
                        coords.Add((row, col));
                        col++;
                    }

                    string numberStr = lines[row].Substring(start, col - start);
                    int number = int.Parse(numberStr);

                    numbers.Add((number, coords));
                }
            }
            
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (map[r, c] != '*')
                        continue;

                    var adjacentNumbers = new List<int>();

                    foreach (var (value, coords) in numbers)
                    {
                        bool touches = coords.Any(pos =>
                        {
                            for (int k = 0; k < 8; k++)
                            {
                                int nr = pos.row + dircol[k];
                                int nc = pos.col + dirrow[k];
                                if (nr == r && nc == c) return true;
                            }
                            return false;
                        });

                        if (touches)
                            adjacentNumbers.Add(value);
                    }

                    if (adjacentNumbers.Count == 2)
                    {
                        sum += (long)adjacentNumbers[0] * adjacentNumbers[1];
                    }
                }
            }

            return sum;
        }
    }
}
