using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0007 : ProblemBase
{
    public override string Title => "10001st Prime";

    public override string Solve()
    {
        var PrimeCounter = 1;
        var primeNumber = 2;
        while (PrimeCounter < 10001)
        {
            primeNumber++;
            if (Primes.IsPrime(primeNumber))
            {
                PrimeCounter++;
            }
        }

        return primeNumber.ToString();
    }

}


