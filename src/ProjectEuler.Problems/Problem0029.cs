using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0029 : ProblemBase
{
    public override string Title => "Distinct Powers";

    public override string Solve()
    {
    var distinctPowers = new HashSet<BigInteger>();
        for (var a = 2; a <= 100; a++)
        {
            for (var b = 2; b <= 100; b++)
            {
                distinctPowers.Add(BigInteger.Pow(a, b));
            }
        }
        return distinctPowers.Count.ToString();
    }
}

