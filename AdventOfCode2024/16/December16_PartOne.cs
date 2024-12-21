using AdventOfCode2024.Tools;

namespace AdventOfCode2024._16;

public static class December16_PartOne
{

    private static List<List<char>> _map = new ();
    private static int _height => _map.Count;
    private static int _width => _map[0].Count;
    private static Point _start;
    private static Point _end;

    public static Point[] Directions { get; } =
    [
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0),
    ];
    
    public static long CalculateLowestReindeerScore()
    {
        long sum = 0;
        List<string> lines = File.ReadLines("../../../16/PuzzleInput.txt").ToList();

        CreateMapAndSetStartEnd(lines);

        sum = FindLowestScore();
        
        return sum;
    }

    private static void CreateMapAndSetStartEnd(List<string> lines)
    {

        for (int y = 0; y < lines.Count; y++)
        {
            List<char> mapRow = new();
            for (int x = 0; x < lines[y].Length; x++)
            {
                mapRow.Add(lines[y][x]);
                if (lines[y][x] == 'S')
                {
                    _start = (x, y);
                }
                if (lines[y][x] == 'E')
                {
                    _end = (x, y);
                }
            }
            _map.Add(mapRow);
        }
    }

    private static long FindLowestScore()
    {
         var states = new PriorityQueue<State, int>();
        var minimumCosts = new Dictionary<State, int>();
        var finalized = new HashSet<State>();

        var startingState = new State(_start, new(1, 0));
        states.Enqueue(startingState, 0);
        minimumCosts.Add(startingState, 0);

        while (states.Count > 0)
        {
            var state = states.Dequeue();
            finalized.Add(state);

            // We go forward
            var next = state.Position + state.Direction;
            var nextState = new State(next, state.Direction);
            AddNextIfImproved(nextState, minimumCosts[state] + 1);

            // We rotate right
            nextState = new State(state.Position, new Point(-state.Direction.Y, state.Direction.X));
            AddNextIfImproved(nextState, minimumCosts[state] + 1000);

            // We rotate left
            nextState = new State(state.Position, new Point(state.Direction.Y, -state.Direction.X));
            AddNextIfImproved(nextState, minimumCosts[state] + 1000);

            void AddNextIfImproved(State nextState, int cost)
            {
                if (nextState.Position.X < 0 || nextState.Position.X >= _width || nextState.Position.Y < 0 || nextState.Position.Y >= _height)
                {
                    return;
                }

                if(_map[nextState.Position.Y][nextState.Position.X] == '#')
                {
                    return;
                }

                if (!finalized.Contains(nextState))
                {
                    if (!minimumCosts.TryGetValue(nextState, out var nextCost) || nextCost > cost)
                    {
                        minimumCosts[nextState] = cost;
                        states.Remove(nextState, out _, out _);
                        states.Enqueue(nextState, minimumCosts[nextState]);
                    }
                }
            }
        }

        var bestEndState = int.MaxValue;
        foreach (var direction in Directions)
        {
            bestEndState = Math.Min(bestEndState, minimumCosts.GetValueOrDefault(new State(_end, direction), int.MaxValue));
        }

        return bestEndState;
    }

    public record State(Point Position, Point Direction);

}