using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015._04;

public class December4_PartOne
{
    private static string _hashResult = "";

    public static long CalculateHashForAdventCoins()
    {
        string input = File.ReadAllText("../../../04/PuzzleInput.txt");

        return CalculateHash(input);
    }

    private static int CalculateHash(string input)
    {

        for (int stepNumber = 0; stepNumber < 100000000; stepNumber++)
        {
            Console.WriteLine($"Calculating hash for {stepNumber}...");
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(Encoding.ASCII.GetBytes(input + stepNumber));
        
            byte[]? result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            _hashResult = strBuilder.ToString();
            
            if (_hashResult.StartsWith("00000"))
            {
                return stepNumber;
            }
        }
        return -1;
    }

}