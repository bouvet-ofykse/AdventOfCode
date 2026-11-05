
namespace AdventOfCode2021._03;

public class December3_PartTwo
{
    public static long CalclateLifeSupportRating()
    {
        var lines = File.ReadLines("../../../03/PuzzleInput.txt").ToArray();

        long zeros = 0;
        long ones = 0;
        IList<string> oxygenGeneratorRatingCandidates = lines.ToList();
        IList<string> co2ScrubberRatingCandidates = lines.ToList();

        for (int row = 0; row < oxygenGeneratorRatingCandidates.First().Length; row++)
        {
            foreach (var line in oxygenGeneratorRatingCandidates)
            {
                switch (line[row])
                {
                    case '0':
                        zeros++;
                        break;
                    case '1':
                        ones++;
                        break;
                }
            }
            
            if (oxygenGeneratorRatingCandidates.Count > 1)
            {
                if (ones >= zeros)
                {

                    oxygenGeneratorRatingCandidates = oxygenGeneratorRatingCandidates
                        .Where(candidate => candidate[row] == '1').ToList();
                }
                else
                {
                    oxygenGeneratorRatingCandidates = oxygenGeneratorRatingCandidates
                            .Where(candidate => candidate[row] == '0').ToList();
                }
            }
            
            zeros = 0;
            ones = 0;
        }

        for (int row = 0; row < co2ScrubberRatingCandidates.First().Length; row++)
        {
            foreach (var line in co2ScrubberRatingCandidates)
            {
                switch (line[row])
                {
                    case '0':
                        zeros++;
                        break;
                    case '1':
                        ones++;
                        break;
                }
            }

            if (co2ScrubberRatingCandidates.Count > 1)
            {
                if (ones >= zeros)
                {
                    co2ScrubberRatingCandidates =
                        co2ScrubberRatingCandidates.Where(candidate => candidate[row] == '0').ToList();
                }
            
                else
                {
                    co2ScrubberRatingCandidates =
                        co2ScrubberRatingCandidates.Where(candidate => candidate[row] == '1').ToList();
                }
            }

            zeros = 0;
            ones = 0;
        }
        
        var oxygenGeneratorRatingDecimal = Convert.ToInt64(oxygenGeneratorRatingCandidates.First(), 2);
        var co2ScrubberRatingDecimal = Convert.ToInt64(co2ScrubberRatingCandidates.First(), 2);
        
        return oxygenGeneratorRatingDecimal * co2ScrubberRatingDecimal;
    }
}