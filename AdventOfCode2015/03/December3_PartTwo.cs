using System.Drawing;

namespace AdventOfCode2015._03;

public class December3_PartTwo
{
    private static Dictionary<Point, int> _housesVisited = new();

    public static long CalculateHousesThatReceivesGifts()
    {
        string directions = File.ReadAllText("../../../03/PuzzleInput.txt");
        var santaPosition = new Point(0, 0);
        var robotPosition = new Point(0, 0);
        bool santasTurn = true;

        _housesVisited.Add(new Point(0, 0), 2);

        foreach (var direction in directions)
        {
            var currentPosition = santasTurn ? santaPosition : robotPosition;
            switch (direction)
            {
                case '^':
                    currentPosition = new Point(currentPosition.X, currentPosition.Y + 1);
                    break;
                case '>':
                    currentPosition = new Point(currentPosition.X + 1, currentPosition.Y);
                    break;
                case 'v':
                    currentPosition = new Point(currentPosition.X, currentPosition.Y - 1);
                    break;
                case '<':
                    currentPosition = new Point(currentPosition.X - 1, currentPosition.Y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }



            // Add or update dictionary
            if (_housesVisited.ContainsKey(currentPosition))
            {
                _housesVisited[currentPosition] = _housesVisited[currentPosition]++;
            }
            else
            {
                _housesVisited.Add(currentPosition, 1);
            }

            if (santasTurn)
            {
                santaPosition = currentPosition;
            }
            else
            {
                robotPosition = currentPosition;
            }
            santasTurn = !santasTurn;
        }

        return _housesVisited.Count;
    }
}