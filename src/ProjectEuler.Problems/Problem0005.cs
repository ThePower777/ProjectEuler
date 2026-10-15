using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0005 : ProblemBase
{
    public override string Title => "Smallest Multiple";

    public override string Solve()
    {
        var smallestDivisible = 2 * 3 * 5 * 7 * 11 * 13 * 17 * 19 * 2 * 2 * 2 * 3; 
        return smallestDivisible.ToString();
    }
}
