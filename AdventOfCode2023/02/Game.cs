namespace AdventOfCode2023._02;

class Game
{
    public long GameId { get; set; }
    public long RedMax { get; set; }
    public long GreenMax { get; set; }
    public long BlueMax { get; set; }

    public long Power => RedMax * GreenMax * BlueMax;

    public Game(long gameId, long redMax, long greenMax, long blueMax)
    {
        GameId = gameId;
        RedMax = redMax;
        GreenMax = greenMax;
        BlueMax = blueMax;        
    }

    public bool IsPossible()
    {
        return RedMax <= 12 && GreenMax <= 13 && BlueMax <= 14;
    }
}