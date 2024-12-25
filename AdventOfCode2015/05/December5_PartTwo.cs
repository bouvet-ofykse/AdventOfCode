using System.Text.RegularExpressions;

namespace AdventOfCode2015._05;

public class December5_PartTwo
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
        bool containsPairOfAnyTwoLetters = Regex.Match(input, @"\w*(\w\w)\w*\1\w*").Success;
        bool containsRepeatingLetterWitchIsSeparated = Regex.Match(input, @"\w*(\w)[^\1]\1\w*").Success;

        return containsPairOfAnyTwoLetters && containsRepeatingLetterWitchIsSeparated;
    }

}