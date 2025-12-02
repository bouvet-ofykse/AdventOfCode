using System.Text.RegularExpressions;

namespace AdventOfCode2023._02;

public class December2_PartTwo
{
    public static long CalculatePowerOfPossibleGames()
    {
        var lines = File.ReadLines("../../../02/PuzzleInput.txt").ToList();
        List<Game> games = new List<Game>();
        long sum = 0;
        

        foreach (var line in lines)
        {
            var idMatch = Regex.Match(line, @"Game (\d+)");
            var gameId = int.Parse(idMatch.Groups[1].Value);

            var reds = Regex.Matches(line, @"(\d+) red")
                .Select(m => int.Parse(m.Groups[1].Value));

            var greens = Regex.Matches(line, @"(\d+) green")
                .Select(m => int.Parse(m.Groups[1].Value));

            var blues = Regex.Matches(line, @"(\d+) blue")
                .Select(m => int.Parse(m.Groups[1].Value));

            games.Add(new Game(
                gameId,
                reds.Any() ? reds.Max() : 0,
                greens.Any() ? greens.Max() : 0,
                blues.Any() ? blues.Max() : 0
            ));
        }

        foreach (var game in games)
        {
            sum += game.Power;
        }

        return sum;
    }
}
