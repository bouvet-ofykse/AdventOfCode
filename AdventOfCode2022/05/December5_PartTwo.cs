using System.Text.RegularExpressions;

namespace AdventOfCode2022._05;

public class December5_PartTwo
{
    public static string RearrangeStacks()
    {
        string result = "";

        // List<string> lines = File.ReadLines("../../../05/TestInput.txt").ToList();
        List<string> lines = File.ReadLines("../../../05/PuzzleInput.txt").ToList();
        List<Command> commands = Command.ParseCommands(lines);
        
        // List<Stack<char>> stacks = PopulateStackWithTestData();
        List<Stack<char>> stacks = PopulateStackWithPuzzleData();

        foreach (var command in commands)
        {
            var toBeMoved = new List<char>();
            for (int i = 0; i < command.Amount; i++)
            {
                toBeMoved.Add(stacks[command.From - 1].Pop());
            }

            toBeMoved.Reverse();        
            for (int i = 0; i < toBeMoved.Count; i++)
            {
                stacks[command.To - 1].Push(toBeMoved[i]);
            }
            toBeMoved.Clear();
        }

        foreach (var stack in stacks)
        {
            result += stack.Peek();
        }

        return result;
    }
    
    private static List<Stack<char>> PopulateStackWithTestData()
    {
        List<Stack<char>> stacks = new List<Stack<char>>();
        var stack1 = new Stack<char>();
        stack1.Push('Z');
        stack1.Push('N');
        stacks.Add(stack1);
        
        var stack2 = new Stack<char>();
        stack2.Push('M');
        stack2.Push('C');
        stack2.Push('D');
        stacks.Add(stack2);    
        
        var stack3 = new Stack<char>();
        stack3.Push('P');
        stacks.Add(stack3);

        return stacks;
    }
    
    private static List<Stack<char>> PopulateStackWithPuzzleData()
    {
        List<Stack<char>> stacks = new List<Stack<char>>();
        var stack1 = new Stack<char>();
        stack1.Push('R');
        stack1.Push('S');
        stack1.Push('L');
        stack1.Push('F');
        stack1.Push('Q');
        stacks.Add(stack1);
        
        var stack2 = new Stack<char>();
        stack2.Push('N');
        stack2.Push('Z');
        stack2.Push('Q');
        stack2.Push('G');
        stack2.Push('P');
        stack2.Push('T');
        stacks.Add(stack2);    
        
        var stack3 = new Stack<char>();
        stack3.Push('S');
        stack3.Push('M');
        stack3.Push('Q');
        stack3.Push('B');
        stacks.Add(stack3);
        
        var stack4 = new Stack<char>();
        stack4.Push('T');
        stack4.Push('G');
        stack4.Push('Z');
        stack4.Push('J');
        stack4.Push('H');
        stack4.Push('C');
        stack4.Push('B');
        stack4.Push('Q');
        stacks.Add(stack4);       
        
        var stack5 = new Stack<char>();
        stack5.Push('P');
        stack5.Push('H');
        stack5.Push('M');
        stack5.Push('B');
        stack5.Push('N');
        stack5.Push('F');
        stack5.Push('S');
        stacks.Add(stack5);      
        
        var stack6 = new Stack<char>();
        stack6.Push('P');
        stack6.Push('C');
        stack6.Push('Q');
        stack6.Push('N');
        stack6.Push('S');
        stack6.Push('L');
        stack6.Push('V');
        stack6.Push('G');
        stacks.Add(stack6);     
        
        var stack7 = new Stack<char>();
        stack7.Push('W');
        stack7.Push('C');
        stack7.Push('F');
        stacks.Add(stack7);
                
        var stack8 = new Stack<char>();
        stack8.Push('Q');
        stack8.Push('H');
        stack8.Push('G');
        stack8.Push('Z');
        stack8.Push('W');
        stack8.Push('V');
        stack8.Push('P');
        stack8.Push('M');
        stacks.Add(stack8);     
        
        var stack9 = new Stack<char>();
        stack9.Push('G');
        stack9.Push('Z');
        stack9.Push('D');
        stack9.Push('L');
        stack9.Push('C');
        stack9.Push('N');
        stack9.Push('R');
        stacks.Add(stack9);  

        return stacks;
    }

}
