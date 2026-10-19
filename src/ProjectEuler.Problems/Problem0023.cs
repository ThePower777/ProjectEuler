using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0023 : ProblemBase
{
    private const int Limit = 28123;
    private const int MaximumAbundantSummand = Limit / 2;

    public override string Title => "Non-Abundant Sums";

    public override string Solve()
    {
        var divisorSums = new int[MaximumAbundantSummand + 1];
        for (var divisor = 1; divisor <= MaximumAbundantSummand / 2; divisor++)
        {
            for (var multiple = divisor * 2; multiple <= MaximumAbundantSummand; multiple += divisor)
            {
                divisorSums[multiple] += divisor;
            }
        }

        var abundantNumbers = new List<int>();
        for (var number = 1; number <= MaximumAbundantSummand; number++)
        {
            if (divisorSums[number] > number)
            {
                abundantNumbers.Add(number);
            }
        }

        var canBeWrittenAsAbundantSum = new bool[Limit + 1];
        for (var i = 0; i < abundantNumbers.Count; i++)
        {
            for (var j = i; j < abundantNumbers.Count; j++)
            {
                var sum = abundantNumbers[i] + abundantNumbers[j];
                if (sum > Limit)
                {
                    break;
                }

                canBeWrittenAsAbundantSum[sum] = true;
            }
        }

        var totalSum = 0;
        for (var number = 1; number <= Limit; number++)
        {
            if (!canBeWrittenAsAbundantSum[number])
            {
                totalSum += number;
            }
        }

        return totalSum.ToString();
    }
}


