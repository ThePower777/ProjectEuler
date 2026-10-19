using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0034 : ProblemBase
{
    private const int MaximumCandidate = 7 * 362880;
    private static readonly int[] DigitFactorials = [1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880];

    public override string Title => "Digit Factorials";

    public override string Solve()
    {
        var totalSum = 0;
        for (var n = 10; n <= MaximumCandidate; n++)
        {
            var sumOfFactorials = 0;
            var temp = n;
            while (temp > 0)
            {
                sumOfFactorials += DigitFactorials[temp % 10];
                temp /= 10;
            }
            if (sumOfFactorials == n)
            {
                totalSum += n;
            }
        }
        return totalSum.ToString();
    }
}



