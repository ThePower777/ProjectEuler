using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0067 : ProblemBase
{
    public override string Title => "Maximum Path Sum II";

    public override string Solve()
    {
        var text = ReadData("p0067.txt").Trim();
        var triangle = text.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToArray();

        var bestSums = (int[])triangle[^1].Clone();
        for (var row = triangle.Length - 2; row >= 0; row--)
        {
            for (var column = 0; column < triangle[row].Length; column++)
            {
                bestSums[column] = triangle[row][column] + Math.Max(bestSums[column], bestSums[column + 1]);
            }
        }

        return bestSums[0].ToString();
    }
}


