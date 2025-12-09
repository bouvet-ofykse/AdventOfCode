
namespace AdventOfCode2025._09
{
    public class December9_PartOne
    {
        public static long CalculateAreaOfTheLargestRectangle()
        {
            long largestArea = 0;
            var lines = File.ReadLines("../../../09/PuzzleInput.txt").ToList();
            var tiles = new List<(long x, long y)>();

            foreach (var line in lines)
            {
                var tile = (long.Parse(line.Split(",")[0]), long.Parse(line.Split(",")[1]));
                tiles.Add(tile);
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                for (int j = i; j < tiles.Count; j++)
                {
                    var tileA = tiles[i];
                    var tileB = tiles[j];
                    
                    var height = Math.Abs(tileA.y - tileB.y) + 1;
                    var width = Math.Abs(tileA.x - tileB.x) + 1;
                    
                    var area = height * width;
                    if (area > largestArea)
                        largestArea = area;
                    
                }
                
            }
            
            return largestArea;
        }
    }
}
