using System;

namespace AdventOfCode2023._03
{
    public class December3_PartOne
    {
        public static long CalcluateSumOfEngineSchematic()
        {
            long sum = 0;
            var lines = File.ReadLines("../../../03/PuzzleInput.txt").ToList();
            int height = lines.Count;
            int width = lines[0].Length;

            char[,] map = new char[height, width];
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    map[r, c] = lines[r][c];
                }
            }

            int[] dircol = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dirrow = { -1, 0, 1, -1, 1, -1, 0, 1 };

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
                    while (col < width && char.IsDigit(map[row, col]))
                    {
                        col++;
                    }

                    int end = col - 1;

                    string numberStr = new string(lines[row].Substring(start, end - start + 1));
                    int number = int.Parse(numberStr);

                    bool isPartNumber = false;

                    for (int cc = start; cc <= end && !isPartNumber; cc++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            int nr = row + dircol[k];
                            int nc = cc + dirrow[k];

                            if (nr < 0 || nr >= height || nc < 0 || nc >= width)
                                continue;

                            char ch = map[nr, nc];

                            if (!char.IsDigit(ch) && ch != '.')
                            {
                                isPartNumber = true;
                                break;
                            }
                        }
                    }

                    if (isPartNumber)
                        sum += number;
                }
            }

            return sum;
        }
    }
}
