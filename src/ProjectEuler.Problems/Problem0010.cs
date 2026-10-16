using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0010 : ProblemBase
{
    private const int Limit = 2_000_000;

    public override string Title => "Summation of Primes";

    public override string Solve()
    {
        var isPrime = Primes.Sieve(Limit - 1);
        long sum = 0;
        for (var i = 2; i < Limit; i++)
        {
            if (isPrime[i])
            {
                sum += i;
            }
        }

        return sum.ToString();
    }
}


