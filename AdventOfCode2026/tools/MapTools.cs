namespace AdventOfCode2025.tools;

public static class MapTools
{
    public static void PrintMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            var row = "";
            for (int j = 0; j < map.GetLength(1); j++)
            {
                row += map[i, j];
            }
            Console.WriteLine(row);
        }
        Console.WriteLine("\n\n");
    }
    
}