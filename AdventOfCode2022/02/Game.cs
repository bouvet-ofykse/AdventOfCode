namespace AdventOfCode2022._01;

public class Game
{
    public string Choice { get; set; }
    public string OpponentsChoice { get; set; }
    public string DesiredOutcome { get; set; }

    public Game()
    {
        
    }
    public Game(string opponentsChoice, string choice)
    {
        Choice = choice;
        OpponentsChoice = opponentsChoice;
    }
    

    // Choice
    // X for Rock, Y for Paper, and Z for Scissors
    // OpponentsChoice
    // A for Rock, B for Paper, and C for Scissors
    
    public int Score()
    {
        // 1 for Rock, 2 for Paper, and 3 for Scissors
        int score = GameResult();
        switch (Choice)
        {
            case "X":
                score += 1;
                break;
            case "Y":
                score += 2;
                break;
            case "Z":
                score += 3;
                break;
        }

        return score;
    }
    
    public void SetChoiceForDesiredOutcome()
    {
        // X = lose
        // Y = draw
        // Z = win
        switch (DesiredOutcome)
        {
            case "X": // lose
                switch (OpponentsChoice)
                {
                    case "A":
                        Choice = "Z"; // scissors
                        break;
                    case "B":
                        Choice = "X"; // rock
                        break;
                    case "C":
                        Choice = "Y"; // paper
                        break;
                }
                break;
            case "Y": // draw
                switch (OpponentsChoice)
                {
                    case "A":
                        Choice = "X"; // rock
                        break;
                    case "B":
                        Choice = "Y"; // paper
                        break;
                    case "C":
                        Choice = "Z"; // scissors
                        break;
                }
                break;
            case "Z": // win
                switch (OpponentsChoice)
                {
                    case "A":
                        Choice = "Y"; // paper
                        break;
                    case "B":
                        Choice = "Z"; // scissors
                        break;
                    case "C":
                        Choice = "X"; // rock
                        break;
                }
                break;
        }
    }
    
    private int GameResult()
    {
        if ((OpponentsChoice == "A" && Choice == "X") ||
            (OpponentsChoice == "B" && Choice == "Y") ||
            (OpponentsChoice == "C" && Choice == "Z"))
        {
            return 3;
        }
        if ((OpponentsChoice == "A" && Choice == "Y") ||
            (OpponentsChoice == "B" && Choice == "Z") ||
            (OpponentsChoice == "C" && Choice == "X"))
        {
            return 6;
        }
        return 0;
    }
    
}