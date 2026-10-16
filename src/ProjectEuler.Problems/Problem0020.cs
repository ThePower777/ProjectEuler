using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0020 : ProblemBase
{
    public override string Title => "Factorial digit sum";

    public override string Solve()
    {
        BigInteger bigFactorial = NumberTheory.Factorial(100);

        //return bigFactorial.ToString().Select(c => int.Parse(c.ToString())).Sum().ToString();
        return DigitHelpers.DigitSum(bigFactorial).ToString();
    }
}


