using ProjectEuler.Core.Utilities;
using Xunit;

namespace ProjectEuler.Tests.Utilities;

public class PrimesTests
{
    [Fact]
    public void Sieve_finds_primes_below_30()
    {
        Assert.Equal([2, 3, 5, 7, 11, 13, 17, 19, 23, 29], Primes.Upto(30));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(97, true)]
    [InlineData(100, false)]
    [InlineData(1_000_000_007, true)]
    public void IsPrime_matches_known_values(long n, bool expected)
    {
        Assert.Equal(expected, Primes.IsPrime(n));
    }

    [Fact]
    public void Factorize_returns_primes_with_exponents()
    {
        Assert.Equal([ (2L, 3), (3L, 2), (5L, 1) ], Primes.Factorize(360));
    }
}
