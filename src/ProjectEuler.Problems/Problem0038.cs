using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0038 : ProblemBase
{

    public override string Title => "Pandigital Multiples";

    public override string Solve()
    {
        var biggestPandigital = 0;
        for (var i = 1; i < 10000; i++)
        {
            var concatenatedProduct = "";
            for (var j = 1; concatenatedProduct.Length < 9; j++)
            {
                concatenatedProduct += (i * j).ToString();
            }
            if (concatenatedProduct.Length == 9 && IsPandigital(concatenatedProduct))
            {
                var pandigitalValue = int.Parse(concatenatedProduct);
                if (pandigitalValue > biggestPandigital)
                {
                    biggestPandigital = pandigitalValue;
                }
            }
        }
        return biggestPandigital.ToString();
    }

    private static bool IsPandigital(string concatenatedProduct)
    {
        var digits = new HashSet<char>(concatenatedProduct);
        return digits.Count == 9 && !digits.Contains('0');
    }
}



