using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0063 : ProblemBase
{
    public override string Title => "Powerful Digit Counts";

    public override string Solve()
    {
        var totalNum = 0;

        for (var baseValue = 1; baseValue <= 9; baseValue++)
        {
            for (var exponent = 1; ; exponent++)
            {
                var power = BigInteger.Pow(baseValue, exponent);
                var digitCount = power.ToString().Length;

                if (digitCount < exponent)
                {
                    break;
                }

                if (digitCount == exponent)
                {
                    totalNum++;
                }
            }
        }

        return totalNum.ToString();
    }
}





