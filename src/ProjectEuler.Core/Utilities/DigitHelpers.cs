using System.Numerics;

namespace ProjectEuler.Core.Utilities;

public static class DigitHelpers
{
    public static int DigitSum(BigInteger n) => n.ToString().Sum(c => c - '0');

    public static int DigitSum(long n)
    {
        n = Math.Abs(n);
        var sum = 0;
        while (n > 0)
        {
            sum += (int)(n % 10);
            n /= 10;
        }

        return sum;
    }

    public static bool IsPalindrome(long n)
    {
        var s = n.ToString();
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                return false;
            }
        }

        return true;
    }
}
