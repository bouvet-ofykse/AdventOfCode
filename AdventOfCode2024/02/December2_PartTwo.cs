namespace AdventOfCode2024._02;

public class December2_PartTwo
{
    public static int CalculateSafeReports()
    {
        string line;
        string content = File.ReadAllText("../../../02/PuzzleInput.txt");
        int safeReports = 0;

        using (StringReader reader = new StringReader(content))
        {
            while ((line = reader.ReadLine()) != null)
            {
                var linelist = line.Split(" ").Select(int.Parse).ToList();

                if (IsSafe(linelist))
                {
                    safeReports++;
                }
            }
        }

        return safeReports;
    }


    private static bool IsSafe(List<int> list)
    {
        // Check if list is safe as it is
        if (IsIncreasingByMaxThree(list) || IsDecreasingByMaxThree(list))
        {
            return true;
        }

        var originalList = new List<int>(list);

        for (int i = 0; i < originalList.Count(); i++)
        {
            list.RemoveAt(i);
            if (IsIncreasingByMaxThree(list) || IsDecreasingByMaxThree(list))
            {
                return true;
            }

            list = new List<int>(originalList);
        }

        return false;
    }

    private static bool IsIncreasingByMaxThree(List<int> list)
    {
        for (int i = 0; i < list.Count() - 1; i++)
        {
            var current = list[i];
            var next = list[i + 1];

            if (next <= current || next - 3 > current)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsDecreasingByMaxThree(List<int> list)
    {
        for (int i = 0; i < list.Count() - 1; i++)
        {
            var current = list[i];
            var next = list[i + 1];

            if (current <= next || next + 3 < current)
            {
                return false;
            }
        }

        return true;
    }
}