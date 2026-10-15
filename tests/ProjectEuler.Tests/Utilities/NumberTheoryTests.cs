using System.Numerics;
using ProjectEuler.Core.Utilities;
using Xunit;

namespace ProjectEuler.Tests.Utilities;

public class NumberTheoryTests
{
    [Fact]
    public void Gcd_and_Lcm()
    {
        Assert.Equal(6, NumberTheory.Gcd(54, 24));
        Assert.Equal(216, NumberTheory.Lcm(54, 24));
    }

    [Fact]
    public void ModPow_matches_small_cases()
    {
        Assert.Equal(445, NumberTheory.ModPow(4, 13, 497));
    }

    [Fact]
    public void Binomial_and_Factorial()
    {
        Assert.Equal(new BigInteger(184756), NumberTheory.Binomial(20, 10));
        Assert.Equal(new BigInteger(10), NumberTheory.Binomial(5, 3));
        Assert.Equal(new BigInteger(3628800), NumberTheory.Factorial(10));
    }
}
