using ProjectEuler.Core.Utilities;
using Xunit;

namespace ProjectEuler.Tests.Utilities;

public class DigitHelpersTests
{
    [Fact]
    public void GetPandigitalNumbers_returns_every_permutation_without_leading_zero()
    {
        Assert.Equal(new long[] { 102, 120, 201, 210 }, DigitHelpers.GetPandigitalNumbers(2));
    }

    [Fact]
    public void GetPandigitalNumbers_includes_zero_when_it_is_the_only_digit()
    {
        Assert.Equal(new long[] { 0 }, DigitHelpers.GetPandigitalNumbers(0));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(10)]
    public void GetPandigitalNumbers_rejects_values_outside_the_digit_range(int value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => DigitHelpers.GetPandigitalNumbers(value));
    }
}
