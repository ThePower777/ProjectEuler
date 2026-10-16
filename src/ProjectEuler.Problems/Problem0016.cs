using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0016: ProblemBase
{
    public override string Title => "Power Digit Sum";

  

    public override string Solve()
    {

        BigInteger bigNumber = 1;
        for (var i = 0; i < 1000; i++)
        {
            bigNumber *= 2;
        }

        return DigitHelpers.DigitSum(bigNumber).ToString();
    }

    
}


