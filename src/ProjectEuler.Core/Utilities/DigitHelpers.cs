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

    public static int GetTriangularNumber(int n) => n * (n + 1) / 2;

    public static int GetSumDivisors(int n)
    {
        if (n < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be a positive integer.");
        }
        var sum = 1+n;
        for (var i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                sum += i;
                if (i != n / i)
                {
                    sum += n / i;
                }
            }
        }
        return sum;
    }

    public static int GetNumDivisors(int n)
    {
        if (n < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be a positive integer.");
        }
        var count = 0;
        for (var i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                count += 2; // i and n/i
                if (i == n / i)
                {
                    count--; // Correct for a perfect square
                }
            }
        }
        return count;
    }

    public static int GetDivisorsCount(int n)
    {
        if (n < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be a positive integer.");
        }
        var count = 2;
        for (var i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                count += 2; // i and n/i
                if (i == n / i)
                {
                    count--; // Correct for a perfect square
                }
            }
        }
        return count;
    }
}
