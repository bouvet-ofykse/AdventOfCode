using AdventOfCode2022._01;

namespace AdventOfCode2022._02;

public class December2_PartTwo
{
    public static long CalculateScoreForStrategyGuide()
    {
        // IEnumerable<string> lines = File.ReadLines("../../../02/TestInput.txt");
        IEnumerable<string> lines = File.ReadLines("../../../02/PuzzleInput.txt");
        List<Game> games = new List<Game>();

        foreach (var line in lines)
        {
            var game = new Game();
            game.OpponentsChoice = line.Split(" ")[0];
            game.DesiredOutcome = line.Split(" ")[1];
            game.SetChoiceForDesiredOutcome();
            games.Add(game);
        }
        
        return games.Sum(game => game.Score());
    }
}