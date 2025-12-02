using System.Text.RegularExpressions;

namespace AdventOfCode2023._04;

public class December4_PartTwo
{
    public static long CalculatePrizeOfWinningCards()
    {
        var lines = File.ReadLines("../../../04/PuzzleInput.txt").ToList();
        var scratchCards = new List<ScratchCard>();

        // Parse input
        foreach (var line in lines)
        {
            var tmp = Regex.Match(line, @"Card\s+\d+").Value;
            int id = int.Parse(Regex.Match(tmp, @"\d+").Value);

            var parts = line.Split(':')[1].Split('|');
            var winning = Regex.Matches(parts[0], @"\d+").Select(m => int.Parse(m.Value)).ToList();
            var nums = Regex.Matches(parts[1], @"\d+").Select(m => int.Parse(m.Value)).ToList();

            scratchCards.Add(new ScratchCard(id, winning, nums));
        }

        long[] copies = new long[scratchCards.Count + 1];

        // Alle kort starter med 1 instans
        for (int i = 1; i <= scratchCards.Count; i++)
            copies[i] = 1;

        // Gå gjennom hvert kort
        for (int i = 1; i <= scratchCards.Count; i++)
        {
            int matches = scratchCards[i - 1].NumberOfPrizes;

            // Hver instans av dette kortet gir kopier til kortene under
            for (int j = 1; j <= matches; j++)
            {
                if (i + j <= scratchCards.Count)
                    copies[i + j] += copies[i];
            }
        }

        return copies.Sum();
    }
}