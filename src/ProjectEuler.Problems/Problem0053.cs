using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0053 : ProblemBase
{
    public override string Title => "Combinatoric Selections";

    public override string Solve()
    {
        var totalNum = 0;
        for(var n = 1; n <= 100; n++)
        {
            for (var r = 1; r <= n; r++)
            {
                var c = DigitHelpers.C(n, r);
                if (c > 1000000)
                {
                    totalNum++;
                }
            }
        }
        return totalNum.ToString();
    }
  


}





