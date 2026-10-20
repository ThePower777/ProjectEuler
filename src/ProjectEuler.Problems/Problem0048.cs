using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0048 : ProblemBase
{
    public override string Title => "Self Powers";

    public override string Solve()
    {
      return GetLastTenDigitsOfSelfPowers(1000).ToString();

    }


    public static BigInteger GetLastTenDigitsOfSelfPowers(int n)
    {
        BigInteger sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += BigInteger.Pow(i, i);
        }
        return sum % 10000000000;
    }



}





