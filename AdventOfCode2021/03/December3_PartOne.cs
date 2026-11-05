namespace AdventOfCode2021._03;

public class December3_PartOne
{
    public static long CalclatePowerConsumption()
    {
        var lines = File.ReadLines("../../../03/PuzzleInput.txt").ToArray();

        long zeros = 0;
        long ones = 0;
        string gammaRate = string.Empty;
        string epsilonRate = string.Empty;

        for (int row = 0; row < lines[0].Length; row++)
        {
            foreach (var line in lines)
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
            gammaRate += zeros > ones ? "0" : "1";
            epsilonRate += zeros > ones ? "1" : "0";
            zeros = 0;
            ones = 0;
        }
        
        var gammaRateDecimal = Convert.ToInt64(gammaRate, 2);
        var epsilonRateDecimal = Convert.ToInt64(epsilonRate, 2);

        return gammaRateDecimal * epsilonRateDecimal;
    }
}