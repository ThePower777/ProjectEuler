using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0023 : ProblemBase
{
    public override string Title => "Non-Abundant Sums";

    public override string Solve()
    {
        var abundantNumbers = new List<int>();
        for (var i = 1; i <= 28123; i++)
        {
            if (i < DigitHelpers.GetSumDivisors(i, false))
            {
                abundantNumbers.Add(i);
            }
        }

        var allPairs = new HashSet<int>();
        for (var i = 0; i < abundantNumbers.Count; i++)
        {
            for (var j = i; j < abundantNumbers.Count; j++)
            {
                var sum = abundantNumbers[i] + abundantNumbers[j];
                if (sum <= 28123)
                {
                    allPairs.Add(sum);
                }
            }
        }

        var totalSum = 0;
        for (var i = 1; i <= 28123; i++)
        {
            if (!allPairs.Contains(i))
            {
                totalSum += i;
            }
        }
        return totalSum.ToString();
    }
}


