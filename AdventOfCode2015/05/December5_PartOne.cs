using System.Text.RegularExpressions;

namespace AdventOfCode2015._05;

public class December5_PartOne
{

    public static long CalculateNumberOfNiceStrings()
    {
        List<string> strings = File.ReadLines("../../../05/PuzzleInput.txt").ToList();
        int sum = 0;

        foreach (var str in strings)
        {
            if (StringIsNice(str)) sum++;
        }
        
        return sum;
    }

    private static bool StringIsNice(string input)
    {
        bool containsAtLeastThreeVowels = Regex.Match(input, @"(\w*[aeiou]\w*){3,}").Success;
        bool containsAtLeastOneLetterThatAppearsTwiceInARow = Regex.Match(input, @"w*(\w)\1{1,}\w*").Success;
        bool containsIllegalStrings = Regex.Match(input, "ab|cd|pq|xy").Success;

        return containsAtLeastThreeVowels && containsAtLeastOneLetterThatAppearsTwiceInARow && !containsIllegalStrings;
    }

}