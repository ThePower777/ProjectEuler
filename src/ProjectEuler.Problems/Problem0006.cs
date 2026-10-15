using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0006 : ProblemBase
{
    public override string Title => "Sum Square Difference";

    public override string Solve()
    {
        return (SumNumbers(100) * SumNumbers(100) - SumSquares(100)).ToString();
    }

    public static int SumSquares(int n) => n * (n + 1) * (2 * n + 1) / 6;

    public static int SumNumbers(int n) => n * (n + 1) / 2;
}
