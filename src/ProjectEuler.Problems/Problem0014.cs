using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0014 : ProblemBase
{
    private const int SearchLimit = 1_000_000;

    public override string Title => "Longest Collatz Sequence";

    public static string Solve2() => FindLongestSequenceStart().ToString();

    public override string Solve() => FindLongestSequenceStart().ToString();

    private static int FindLongestSequenceStart()
    {
        var lengths = new int[SearchLimit];
        lengths[1] = 1;
        var path = new List<long>();
        var longestStart = 1;
        var longestLength = 1;

        for (var start = 2; start < SearchLimit; start++)
        {
            var current = (long)start;
            path.Clear();

            while (current >= SearchLimit || lengths[(int)current] == 0)
            {
                path.Add(current);
                current = current % 2 == 0 ? current / 2 : 3 * current + 1;
            }

            var length = lengths[(int)current];
            for (var index = path.Count - 1; index >= 0; index--)
            {
                length++;
                var value = path[index];
                if (value < SearchLimit)
                {
                    lengths[(int)value] = length;
                }
            }

            if (lengths[start] > longestLength)
            {
                longestLength = lengths[start];
                longestStart = start;
            }
        }

        return longestStart;
    }
}


