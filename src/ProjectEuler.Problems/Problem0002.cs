using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0002 : ProblemBase
{
    public override string Title => "Even Fibonacci Numbers";

    public override string Solve()
    {
        long a = 1, b = 2, sum = 0;
        while (b <= 4_000_000)
        {
            if (b % 2 == 0)
            {
                sum += b;
            }

            (a, b) = (b, a + b);
        }

        return sum.ToString();
    }
}
