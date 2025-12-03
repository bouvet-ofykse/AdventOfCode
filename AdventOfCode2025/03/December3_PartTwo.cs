namespace AdventOfCode2025._03;

public class December3_PartTwo
{
    public static long CalculateSumJoltage()
    {
        var banks = File.ReadLines("../../../03/PuzzleInput.txt").ToList();
        long sum = 0;
        
        foreach (var bank in banks)
        {
            int k = 12;
            var stack = new List<char>();

            for (int i = 0; i < bank.Length; i++)
            {
                char currentDigit = bank[i];
                
                while (stack.Count > 0 && stack[^1] < currentDigit && (bank.Length - i) > (k - stack.Count))
                {
                    stack.RemoveAt(stack.Count - 1);
                }
                
                if (stack.Count < k)
                {
                    stack.Add(currentDigit);
                }

            }
            var bankOutputjoltage = long.Parse(new string(stack.ToArray()));
            sum += bankOutputjoltage;
        }
        return sum;
    }
}