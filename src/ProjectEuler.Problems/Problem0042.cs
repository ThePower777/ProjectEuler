using ProjectEuler.Core;
using ProjectEuler.Core.Utilities;

namespace ProjectEuler.Problems;

public sealed class Problem0042 : ProblemBase
{
    public override string Title => "Coded Triangle Numbers";

    public override string Solve()
    {
        var words = ReadData("p0042.txt")
           .Split(',')
           .Select(name => name.Trim().Trim('"'))
           .OrderBy(name => name, StringComparer.Ordinal)
           .ToList();


        var triangleNumbers = new HashSet<int>();
        for (var n = 1; n <= 20; n++)
        {
            triangleNumbers.Add(n * (n + 1) / 2);
        }

        var triangleWordCount = words.Count(word => triangleNumbers.Contains(GetWordValue(word)));
        return triangleWordCount.ToString();
    }


    public static int GetWordValue(string word)
    {
        return word.Sum(character => character - 'A' + 1);
    }



}





