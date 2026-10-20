using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0045 : ProblemBase
{
    public override string Title => "Triangular, Pentagonal, and Hexagonal";

    public override string Solve()
    {
        var HexagonalIndex = 144;
        while (true)
        {
            var hexagonalNumber = DigitHelpers.GetHexagonNumber(HexagonalIndex);
            if (hexagonalNumber > 40755)
            {
                if (DigitHelpers.IsPentagonal(hexagonalNumber) && DigitHelpers.IsTriangular(hexagonalNumber))
                {
                    return hexagonalNumber.ToString();
                }
            }
            HexagonalIndex++;
        }
    }
}





