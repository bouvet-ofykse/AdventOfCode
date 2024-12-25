namespace AdventOfCode2015._1;

public class December1_PartTwo
{
    public static int CalculateFloors()
    {
        List<char> symbols = File.ReadAllText("../../../01/PuzzleInput.txt").ToList();
        int currentFloor = 0;

        for (int i = 0; i < symbols.Count +1; i++)
        {
            if (symbols[i] == '(') currentFloor++;
            if (symbols[i] == ')') currentFloor--;
            if (currentFloor == -1)
            {
                return i + 1;
            }
        }

        return currentFloor;
    }
}