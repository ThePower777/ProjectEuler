using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0012 : ProblemBase
{
    public override string Title => "Highly Divisible Triangular Number";

    public override string Solve()
    {

        var divisorCount = 0;
        var i = 1;
        while (divisorCount < 500)
        {
            var triangleNumber = DigitHelpers.GetTriangularNumber(i);
            divisorCount = DigitHelpers.GetNumDivisors(triangleNumber);
            i++;
        }
        return DigitHelpers.GetTriangularNumber(i-1).ToString();
    }
}


