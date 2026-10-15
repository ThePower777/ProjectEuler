namespace ProjectEuler.Core.Utilities;

public static class Primes
{
    /// <summary>Sieve of Eratosthenes. Index i is true when i is prime. Length is limit + 1.</summary>
    public static bool[] Sieve(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);

        var isPrime = new bool[limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = false;
        if (limit >= 1)
        {
            isPrime[1] = false;
        }

        for (long i = 2; i * i <= limit; i++)
        {
            if (!isPrime[i])
            {
                continue;
            }

            for (var j = (int)(i * i); j <= limit; j += (int)i)
            {
                isPrime[j] = false;
            }
        }

        return isPrime;
    }

    /// <summary>All primes up to and including <paramref name="limit"/>.</summary>
    public static IEnumerable<int> Upto(int limit)
    {
        var sieve = Sieve(limit);
        for (var i = 2; i <= limit; i++)
        {
            if (sieve[i])
            {
                yield return i;
            }
        }
    }

    /// <summary>Trial-division primality test, fine for values up to ~10^12.</summary>
    public static bool IsPrime(long n)
    {
        if (n < 2)
        {
            return false;
        }

        if (n < 4)
        {
            return true;
        }

        if (n % 2 == 0 || n % 3 == 0)
        {
            return false;
        }

        for (long i = 5; i * i <= n; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>Prime factorisation as (prime, exponent) pairs in ascending order.</summary>
    public static IEnumerable<(long Prime, int Exponent)> Factorize(long n)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(n, 2);

        for (long p = 2; p * p <= n; p++)
        {
            if (n % p != 0)
            {
                continue;
            }

            var e = 0;
            while (n % p == 0)
            {
                n /= p;
                e++;
            }

            yield return (p, e);
        }

        if (n > 1)
        {
            yield return (n, 1);
        }
    }
}
