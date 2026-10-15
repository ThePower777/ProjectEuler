using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0003 : ProblemBase
{
    public override string Title => "Largest Prime Factor";

    public override string Solve() =>
        Primes.Factorize(600_851_475_143).Max(f => f.Prime).ToString();
}
