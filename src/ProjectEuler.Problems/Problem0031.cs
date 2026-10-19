using System.Numerics;
using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0031 : ProblemBase
{
    public override string Title => "Coin Sums";

    public override string Solve()
    {
        var listOfCoins = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
        var targetAmount = 200;
        var numberOfWays = CountWaysToMakeChange(listOfCoins, targetAmount);
        return numberOfWays.ToString();
    }

    private static int CountWaysToMakeChange(List<int> listOfCoins, int targetAmount)
    {
        var ways = new int[targetAmount + 1];
        ways[0] = 1;

        foreach (var coin in listOfCoins)
        {
            for (var amount = coin; amount <= targetAmount; amount++)
            {
                ways[amount] += ways[amount - coin];
            }
        }

        return ways[targetAmount];
    }
}

    

