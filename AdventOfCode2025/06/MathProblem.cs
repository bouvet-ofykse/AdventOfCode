using System.Numerics;

namespace AdventOfCode2025._06;

public class MathProblem
{
    public string Operator { get; set; } = string.Empty;
    public List<long> Operands { get; set; } = new ();
        
    public BigInteger Solve()
    {
        BigInteger result = 0;
        switch (Operator)
        {
            case "+":
                result = Operands.Sum();
                break;
            case "*":
                result = Operands.Aggregate(1L, (acc, val) => acc * val);
                break;
        }

        return result;
    }        
    
}