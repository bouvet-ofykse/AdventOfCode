using AdventOfCode2022._01;

namespace AdventOfCode2022._02;

public class December2_PartOne
{
    public static long CalculateScoreForStrategyGuide()
    {
        // IEnumerable<string> lines = File.ReadLines("../../../02/TestInput.txt");
        IEnumerable<string> lines = File.ReadLines("../../../02/PuzzleInput.txt");
        List<Game> games = new List<Game>();

        foreach (var line in lines)
        {
            games.Add(new Game(line.Split(" ")[0], line.Split(" ")[1]));
        }
        
        return games.Sum(game => game.Score());
    }
}