using System.Text.RegularExpressions;

namespace AdventOfCode2023._04;

public class December4_PartOne
{
    public static long CalculatePrizeOfWinningCards()
    {
        var lines = File.ReadLines("../../../04/PuzzleInput.txt").ToList();
        List<ScratchCard> scratchCards = new List<ScratchCard>();
        long sum = 0;

        foreach (var line in lines)
        {
            
            var temp = Regex.Match(line, @"Card\s+\d+").Groups[0].Value;
            var gameId = int.Parse(Regex.Matches(temp, @"\d+").First().Value);

            var allNumbers = line.Split(':')[1];
            var winningNumbers = Regex.Matches(allNumbers.Split('|')[0], @"\d+").Select(match => int.Parse(match.Value)).ToList();
            var numbers = Regex.Matches(allNumbers.Split('|')[1], @"\d+").Select(match => int.Parse(match.Value)).ToList();

            scratchCards.Add(new ScratchCard(gameId, winningNumbers, numbers));

        }

        foreach (var card in scratchCards)
        {
            sum += card.TotalPrizePoints;
        }
        
        return sum;
    }
}