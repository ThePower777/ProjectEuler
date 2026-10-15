using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0010 : ProblemBase
{
    public override string Title => "Summation of Primes";

    public override string Solve()
    {
        BigInteger sum = 2;
        for(var i = 3; i < 2000000; i += 2)
        {
            if (Primes.IsPrime(i))
            {
                sum += i;
            }
        }
        return sum.ToString();

    }
}


