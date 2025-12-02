namespace AdventOfCode2025._02;

public class December2_PartOne
{
    public static long CalculateSumOfInvalidIds()
    {
        var idRanges = File.ReadAllText("../../../02/PuzzleInput.txt").Split(',');
        List<long> invalidIds = new List<long>();

        foreach (var idRange in idRanges)
        {
            var start = long.Parse(idRange.Split('-')[0]);
            var end = long.Parse(idRange.Split('-')[1]);

            for (long id = start; id < end + 1; id++)
            {
                var idAsString = id.ToString();
                if (idAsString.Length % 2 == 1)
                {
                    continue;
                }
                var firstpart = idAsString.Substring(0, idAsString.Length / 2);
                var secondpart = idAsString.Substring(idAsString.Length / 2);
                if (firstpart == secondpart)
                {
                    invalidIds.Add(id);
                }
            }
        }
        return invalidIds.Sum(id => id);
    }
}