using System.Numerics;

namespace ProjectEuler.Core.Utilities;

public static class NumberTheory
{
    public static long Gcd(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    public static long Lcm(long a, long b) => a / Gcd(a, b) * b;

    /// <summary>Computes (b^e) mod m without overflow for m up to ~3·10^9.</summary>
    public static long ModPow(long b, long e, long m)
    {
        return (long)BigInteger.ModPow(b, e, m);
    }

    public static BigInteger Factorial(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(n);

        BigInteger result = BigInteger.One;
        for (var i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>Number of ways to choose k items from n (n choose k).</summary>
    public static BigInteger Binomial(int n, int k)
    {
        if (k < 0 || k > n)
        {
            return BigInteger.Zero;
        }

        k = Math.Min(k, n - k);
        BigInteger result = BigInteger.One;
        for (var i = 1; i <= k; i++)
        {
            result = result * (n - k + i) / i;
        }

        return result;
    }
}
