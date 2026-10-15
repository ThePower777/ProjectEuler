using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0009 : ProblemBase
{
    public override string Title => "Special Pythagorean Triplet";

    public override string Solve()
    {
        // x == a^2-b^2
        // y = 2ab
        // z = a^2+b^2
        var a = 1;

        while (true)
        {
            for (var b = 1; b < a; b++)
            {
                var x = a * a - b * b;
                var y = 2 * a * b;
                var z = a * a + b * b;
                if (x + y + z == 1000)
                {
                    return (x * y * z).ToString();
                }
            }
            a++;
        }
    }
}


