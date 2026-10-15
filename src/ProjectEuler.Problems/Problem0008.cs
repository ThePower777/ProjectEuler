using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0008 : ProblemBase
{
    public override string Title => "Largest Product in a Series";

    public override string Solve()
    {
        var bigNumber = ReadData("p0008.txt").Trim();
        BigInteger bigProduct = 0;

        for (var i=0; i < bigNumber.Length - 13; i++)
        {
            BigInteger product = 1;
            for (var j = 0; j < 13; j++)
            {
                product *= int.Parse(bigNumber[i + j].ToString());
            }
            if (product > bigProduct)
            {
                bigProduct = product;                
            }
        }

        return bigProduct.ToString();
    }


}


