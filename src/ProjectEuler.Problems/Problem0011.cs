using System.Numerics;
using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0011 : ProblemBase
{
    public override string Title => "Largest Product in a Grid";

    public override string Solve()
    {
        var grid = ReadData("p0011.txt").Trim();
        var rows = grid.Split('\n');
        var gridValues = new int[rows.Length][];
        for (var i = 0; i < rows.Length; i++)
        {
            gridValues[i] = [.. rows[i].Replace("\r","").Split().Select(int.Parse)];
        }

        var maxProduct = 0;
        for (var i = 0; i < gridValues.Length; i++)
        {
            for (var j = 0; j < gridValues[i].Length; j++)
            {
                // Check right
                if (j + 3 < gridValues[i].Length)
                {
                    var product = gridValues[i][j] * gridValues[i][j + 1] * gridValues[i][j + 2] * gridValues[i][j + 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }

                // Check down
                if (i + 3 < gridValues.Length)
                {
                    var product = gridValues[i][j] * gridValues[i + 1][j] * gridValues[i + 2][j] * gridValues[i + 3][j];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }

                // Check diagonal down-right
                if (i + 3 < gridValues.Length && j + 3 < gridValues[i].Length)
                {
                    var product = gridValues[i][j] * gridValues[i + 1][j + 1] * gridValues[i + 2][j + 2] * gridValues[i + 3][j + 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }

                // Check diagonal down-left
                if (i + 3 < gridValues.Length && j - 3 >= 0)
                {
                    var product = gridValues[i][j] * gridValues[i + 1][j - 1] * gridValues[i + 2][j - 2] * gridValues[i + 3][j - 3];
                    if (product > maxProduct)
                    {
                        maxProduct = product;
                    }
                }
            }
        }

        return maxProduct.ToString();
    }
}


