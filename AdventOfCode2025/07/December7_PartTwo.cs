
namespace AdventOfCode2025._07
{
    public class December7_PartTwo
    {
        public static long CalculateNumberOfTimelines()
        {
            long timelines = 0;
            long startCol = 0;
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
                        startCol = c;
                        map[r, c] = 'S';
                        map[r + 1, c] = '|';
                    }
                    else
                    {
                        if (map[r, c] != '|')
                        {
                            map[r, c] = lines[r][c];
                        }
                    }
                }
            }

            long[] currentTimelines = new long[width];
            long[] nextRowTimelines = new long[width];
            currentTimelines[startCol] = 1;

            for (int r = 0; r < height - 1; r++)
            {
                Array.Clear(nextRowTimelines, 0, width);

                for (int c = 0; c < width; c++)
                {
                    long here = currentTimelines[c];
                    if (here == 0)
                        continue;

                    char cellBelow = map[r + 1, c];

                    if (cellBelow == '.')
                    {
                        nextRowTimelines[c] += here;
                    }
                    else if (cellBelow == '^')
                    {
                        if (c - 1 >= 0) nextRowTimelines[c - 1] += here;
                        if (c + 1 < width) nextRowTimelines[c + 1] += here;
                    }
                    else
                    {
                        nextRowTimelines[c] += here;
                    }
                }
                // swap
                (currentTimelines, nextRowTimelines) = (nextRowTimelines, currentTimelines);
            }

            timelines = currentTimelines.Sum();
            return timelines;
        }
    }
}
