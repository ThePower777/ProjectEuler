using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0025 : ProblemBase
{
   

    public override string Title => "1000-digit Fibonacci Number";

    public override string Solve()
    {
        BigInteger previous = 1;
        BigInteger current = 1;
        var index = 2;

        while (current.ToString().Length < 1000)
        {
            (previous, current) = (current, previous + current);
            index++;
        }

        return index.ToString();
    }
}


