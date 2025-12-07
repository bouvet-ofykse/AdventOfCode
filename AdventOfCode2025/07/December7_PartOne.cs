
using AdventOfCode2025.tools;

namespace AdventOfCode2025._07
{
    public class December7_PartOne
    {
        public static long CalculateBeamSplits()
        {
            long splits = 0;
            var lines = File.ReadLines("../../../07/PuzzleInput.txt").ToList();

            int height = lines.Count;
            int width = lines[0].Length;

            char[,] map = new char[height, width];
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (lines[r][c] == 'S')
                    {
                        map[r, c] = 'S';
                        map[r + 1, c] = '|';
                    }
                    else
                    {
                        if (map[r,c] != '|')
                        {
                            map[r, c] = lines[r][c];
                        }
                    }
                }
            }
  
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (r + 1 >= height)
                        break;
                    if (map[r,c] == '|')
                    {
                        if (map[r + 1, c] == '^')
                        {
                            map[r + 1, c + 1] = '|';
                            map[r + 1, c - 1] = '|';
                            splits++;
                        }
                        else
                        {
                            map[r + 1, c] = '|';
                        }
                    }
                }
            }
            MapTools.PrintMap(map);
            
            return splits;
        }
    }
}
