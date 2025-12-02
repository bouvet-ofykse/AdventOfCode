namespace AdventOfCode2023._04;

public class ScratchCard
{
    public int Id { get; }

    public List<int> Numbers { get; set; }
    public List<int> WinningNumbers { get; set; }
    public int NumberOfPrizes => WinningNumbers.Intersect(Numbers).Count();
    public int TotalPrizePoints => (int)(1 * Math.Pow(2, NumberOfPrizes - 1));

    public ScratchCard(int id, List<int> winningNumbers, List<int> numbers)
    {
        Id = id;
        WinningNumbers = winningNumbers;
        Numbers = numbers;
    }
}