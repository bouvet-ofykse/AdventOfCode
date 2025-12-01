
namespace AdventOfCode2023._01
{
    public class December1_PartTwo
    {
        static readonly Dictionary<string, char> Words = new()
        {
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' }
        };

        public static long CalibrateDocument()
        {
            long sum = 0;

            var lines = File.ReadLines("../../../01/PuzzleInput.txt");

            foreach (var line in lines)
            {
                List<char> digits = new();

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];

                    if (char.IsDigit(c))
                    {
                        digits.Add(c);
                        continue;
                    }

                    foreach (var kvp in Words)
                    {
                        string word = kvp.Key;

                        if (i + word.Length <= line.Length &&
                            line.Substring(i, word.Length)
                                .Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            digits.Add(kvp.Value);
                            break;
                        }
                    }
                }

                char first = digits.First();
                char last = digits.Last();

                sum += long.Parse($"{first}{last}");
            }

            return sum;
        }
    }
}