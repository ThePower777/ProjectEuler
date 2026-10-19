using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0012 : ProblemBase
{
    public override string Title => "Highly Divisible Triangular Number";

    public override string Solve()
    {
        for (var i = 1; ; i++)
        {
            var firstFactor = i;
            var secondFactor = i + 1;
            if (firstFactor % 2 == 0)
            {
                firstFactor /= 2;
            }
            else
            {
                secondFactor /= 2;
            }

            var divisorCount = DigitHelpers.GetNumDivisors(firstFactor)
                * DigitHelpers.GetNumDivisors(secondFactor);
            if (divisorCount >= 500)
            {
                return DigitHelpers.GetTriangularNumber(i).ToString();
            }
        }
    }
}


