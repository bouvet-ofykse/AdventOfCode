namespace AdventOfCode2015._1;

public class December1_PartOne
{
    public static int CalculateFloors()
    {
        List<char> symbols = File.ReadAllText("../../../01/PuzzleInput.txt").ToList();
        int currentFloor = 0;

        foreach (var symbol in symbols)
        {
            if (symbol == '(') currentFloor++;
            if (symbol == ')') currentFloor--;
        }

        return currentFloor;
    }
}