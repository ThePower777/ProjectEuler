using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0030 : ProblemBase
{
    private static readonly int[] FifthPowers = { 0, 1, 32, 243, 1024, 3125, 7776, 16807, 32768, 59049 };

    public override string Title => "Digit Fifth Powers";

    public override string Solve()
    {
        var sum = 0L;
        for (var n = 2; n < 1000000; n++)
        {
            var digitSum = 0L;
            var temp = n;
            while (temp > 0)
            {
                digitSum += FifthPowers[temp % 10];
                temp /= 10;
            }
            if (digitSum == n)
            {
                sum += n;
            }
        }
        return sum.ToString();
    }
}

    

