using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0022 : ProblemBase
{
    public override string Title => "Names Scores";

    public override string Solve()
    {
        var names = ReadData("p0022.txt")
            .Split(',')
            .Select(name => name.Trim().Trim('"'))
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToList();

        var totalScore = names
            .Select((name, index) => name.Sum(character => character - 'A' + 1) * (index + 1))
            .Sum();

        return totalScore.ToString();
    }
}


