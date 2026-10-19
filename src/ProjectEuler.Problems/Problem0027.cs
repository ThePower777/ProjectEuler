using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0027 : ProblemBase
{
    public override string Title => "Quadratic Primes";

    public override string Solve()
    {
        var _maxN = 0;
        var _maxA = 0;
        var _maxB = 0;

        for (var a = -999; a < 1000; a++)
        {
            for (var b = -1000; b <= 1000; b++)
            {
                var n = 0;
                while (Core.Utilities.Primes.IsPrime(n * n + a * n + b))
                {
                    n++;
                }
                if (n > _maxN)
                {
                    _maxN = n;
                    _maxA = a;
                    _maxB = b;
                }
            }
        }
        return (_maxA * _maxB).ToString();

    }


}


