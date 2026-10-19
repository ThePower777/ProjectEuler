using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0030 : ProblemBase
{
    public override string Title => "Digit Fifth Powers";

    public override string Solve()
    {
        var sum = 0L;
        for (var n = 2; n < 1000000; n++)
        {
            var digitSum = 0L;
            var temp = n;
            while (temp > 0)
            {
                digitSum += (long)BigInteger.Pow(temp % 10, 5);
                temp /= 10;
            }
            if (digitSum == n)
            {
                sum += n;
            }
        }
        return sum.ToString();
    }
}

    

