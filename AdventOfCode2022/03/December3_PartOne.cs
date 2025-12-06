namespace AdventOfCode2022._03;

public class December3_PartOne
{
    public static long CalculateSumOfPriorities()
    {
        long sum = 0;
        IEnumerable<string> lines = File.ReadLines("../../../03/PuzzleInput.txt");

        foreach (var line in lines)
        {
            int compartmentSize = line.Length / 2;
            string compartmentOne = line.Substring(0, compartmentSize);
            string compartmentTwo = line.Substring(compartmentSize, compartmentSize);
            
            var appersInBoth = compartmentOne.Intersect(compartmentTwo);
            sum += LetterToNumber(appersInBoth.First());
            
        }
        return sum;
    }
    
    private static int LetterToNumber(char c)
    {
        return c == char.ToLower(c) ? c - 'a' + 1 : c - 'A' + 27;
    }
    
}