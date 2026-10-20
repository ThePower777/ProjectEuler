using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0044 : ProblemBase
{
    public override string Title => "Pentagon Numbers";

    public override string Solve()
    {
        var pentagonNumbers = new HashSet<long>();
        for (var i = 1; i <= 3000; i++)
        {
            pentagonNumbers.Add(DigitHelpers.GetPentagonNumber(i));
        }

        var minDifference = long.MaxValue;
        for(var i=1; i<pentagonNumbers.Count; i++)
        {
            var pi = DigitHelpers.GetPentagonNumber(i);
            for (var j = i - 1; j > 0; j--)
            {
                var pj = DigitHelpers.GetPentagonNumber(j);
                if (pentagonNumbers.Contains(pi + pj) && pentagonNumbers.Contains(pi - pj))
                {
                    var difference = pi - pj;
                    if (difference < minDifference)
                    {
                        minDifference = difference;
                    }
                }
            }
        }

        return minDifference.ToString();



    }
}





