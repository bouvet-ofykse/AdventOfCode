using AdventOfCode2025.tools;

namespace AdventOfCode2025._04
{
    public class December4_PartTwo
    {
        public static long ClalculateRollsOfPaperRemovedByForklift()
        {
            long sum = 0;
            var lines = File.ReadLines("../../../04/PuzzleInput.txt").ToList();
            int height = lines.Count;
            int width = lines[0].Length;
            var removedRolls = 0;

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
            while (true)
            {

                removedRolls = 0;
                for (int row = 0; row < height; row++)
                {
                    int col = 0;

                    while (col < width)
                    {
                        if (map[row, col] == 'x')
                        {
                            map[row, col] = '.';
                        }
                        if (map[row, col] == '@')
                        {
                            var numberOfAdjecentRolls = 0;
                            for (int k = 0; k < 8; k++)
                            {
                                int nr = row + dircol[k];
                                int nc = col + dirrow[k];
                                if (nr < 0 || nr >= height || nc < 0 || nc >= width)
                                    continue;
                                if (map[nr, nc] == '@')
                                {
                                    numberOfAdjecentRolls++;
                                }
                            }

                            if (numberOfAdjecentRolls < 4)
                            {
                                map[row, col] = 'x';
                                removedRolls++;
                                sum++;
                            }
                        }
                        col++;
                    }
                }
                MapTools.PrintMap(map);
                Console.WriteLine($"Removed {removedRolls} rolls of paper");
                if (removedRolls == 0)
                {
                    break;
                }
            }
            return sum;
        }

    }
}