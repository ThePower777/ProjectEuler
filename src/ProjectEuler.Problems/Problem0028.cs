using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0028 : ProblemBase
{
    public override string Title => "Number Spiral Diagonals";

    public override string Solve()
    {
        const int size = 1001;
        var cellCount = size * size;
        var spiral = new int[size, size];
        var rowOffsets = new[] { 0, 1, 0, -1 };
        var columnOffsets = new[] { 1, 0, -1, 0 };
        var row = size / 2;
        var column = size / 2;
        var value = 1;
        var segmentLength = 1;
        spiral[row, column] = value;

        while (value < cellCount)
        {
            for (var direction = 0; direction < 4 && value < cellCount; direction++)
            {
                for (var step = 0; step < segmentLength && value < cellCount; step++)
                {
                    row += rowOffsets[direction];
                    column += columnOffsets[direction];
                    spiral[row, column] = ++value;
                }

                if (direction % 2 == 1)
                {
                    segmentLength++;
                }
            }
        }

        var sum = 0L;
        for (var index = 0; index < size; index++)
        {
            sum += spiral[index, index];
            if (index != size - index - 1)
            {
                sum += spiral[index, size - index - 1];
            }
        }

        return sum.ToString(); 
    }
}

