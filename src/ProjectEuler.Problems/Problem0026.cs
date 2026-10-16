using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0026 : ProblemBase
{
    public override string Title => "Reciprocal Cycles";

    public override string Solve()
    {
        var longestCycleLength = 0;
        var denominatorWithLongestCycle = 0;

        for (var denominator = 2; denominator < 1000; denominator++)
        {
            var cycleLength = GetRecurringCycleLength(denominator);
            if (cycleLength > longestCycleLength)
            {
                longestCycleLength = cycleLength;
                denominatorWithLongestCycle = denominator;
            }
        }

        return denominatorWithLongestCycle.ToString();
    }

    private static int GetRecurringCycleLength(int denominator)
    {
        var firstSeenAt = new Dictionary<int, int>();
        var remainder = 1;
        var position = 0;

        while (remainder != 0 && !firstSeenAt.ContainsKey(remainder))
        {
            firstSeenAt[remainder] = position;
            remainder = remainder * 10 % denominator;
            position++;
        }

        return remainder == 0 ? 0 : position - firstSeenAt[remainder];
    }
}


