using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0021 : ProblemBase
{
    public override string Title => "Amicable Numbers";

    public override string Solve()
    {
        var totalSum = 0;
        for (var i = 2; i < 10000; i++)
        {
            var sumOfDivisors = DigitHelpers.GetSumDivisors(i, false);
            if (i !=sumOfDivisors && DigitHelpers.GetSumDivisors(sumOfDivisors, false) == i)
            {
                totalSum += i+ sumOfDivisors;
            }   
        }
        return (totalSum / 2).ToString();
    }
}


