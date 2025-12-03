namespace AdventOfCode2025._03;

public class December3_PartOne
{
    public static long CalculateSumJoltage()
    {
        var banks = File.ReadLines("../../../03/PuzzleInput.txt").ToList();
        long sum = 0;
        
        foreach (var bank in banks)
        {
            long currentMax = 0;
            for (int i = 0; i < bank.Length; i++)
            {
                var firstDigit = bank[i];
                for (int j = i + 1; j < bank.Length; j++)
                {
                    var secondDigit = bank[j];
                    var tempSum = long.Parse($"{firstDigit}{secondDigit}");
                    if (tempSum > currentMax)
                    {
                        currentMax = tempSum;
                    }
                }
            }
            Console.WriteLine(currentMax);
            sum += currentMax;
        }
        return sum;
    }
}