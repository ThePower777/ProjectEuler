using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0013: ProblemBase
{
    public override string Title => "Large Sum";

    public override string Solve()
    {

        var text = ReadData("p0013.txt").Trim();
        var lines = text.Split('\n');
        var sum = BigInteger.Zero;
        foreach (var line in lines)
        {
            sum += BigInteger.Parse(line);
        }
        return sum.ToString()[..10] ;
    }
}


