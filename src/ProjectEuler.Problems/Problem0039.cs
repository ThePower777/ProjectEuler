using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0039 : ProblemBase
{
    public override string Title => "Integer Right Triangles";

    public override string Solve()
    {
        const int maxPerimeter = 1000;
        var solutionCounts = new int[maxPerimeter + 1];

        for (var m = 2; 2 * m * (m + 1) <= maxPerimeter; m++)
        {
            for (var n = 1; n < m; n++)
            {
                var primitivePerimeter = 2 * m * (m + n);
                if (primitivePerimeter > maxPerimeter)
                {
                    break;
                }

                if ((m - n) % 2 == 0 || NumberTheory.Gcd(m, n) != 1)
                {
                    continue;
                }

                for (var perimeter = primitivePerimeter; perimeter <= maxPerimeter; perimeter += primitivePerimeter)
                {
                    solutionCounts[perimeter]++;
                }
            }
        }

        var bestPerimeter = 0;
        for (var perimeter = 12; perimeter <= maxPerimeter; perimeter++)
        {
            if (solutionCounts[perimeter] > solutionCounts[bestPerimeter])
            {
                bestPerimeter = perimeter;
            }
        }

        return bestPerimeter.ToString();
    }
}





