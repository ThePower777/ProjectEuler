using System.Net.WebSockets;
using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0033 : ProblemBase
{
    public override string Title => "Digit Cancelling Fractions";

    public override string Solve()
    {
        var globalNumerator = 1;
        var globalDenominator = 1;
        for (var i=1; i < 10; i++)
        {
            for (var j = 1; j < 10; j++)
            {
                for (var k = 1; k < 10; k++)
                {
                    var numerator = 10 * i + j;
                    var denominator = 10 * j + k;
                    if (numerator < denominator && numerator * k == denominator * i)
                    {
                        //return $"{numerator}/{denominator}";
                        globalNumerator *= numerator;
                        globalDenominator *= denominator;
                    }
                }
            }
        }

        var gcd = BigInteger.GreatestCommonDivisor(globalNumerator, globalDenominator);

        return (globalDenominator / gcd).ToString();
    }   
}

    

