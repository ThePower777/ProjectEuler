using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0004 : ProblemBase
{
    public override string Title => "Largest Palindrome Product";

    public override string Solve()
    {
        var maxPalindrome = 0;
        for (var i = 999; i > 99; i--)
        {
            for (var j = 999; j > 99; j--)
            {
                var product = i * j;
                if (product > maxPalindrome && DigitHelpers.IsPalindrome(product))
                {
                    maxPalindrome = product;
                }
            }
        }
        return maxPalindrome.ToString();
    }
}
