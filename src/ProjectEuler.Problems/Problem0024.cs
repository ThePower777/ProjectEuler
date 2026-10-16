using ProjectEuler.Core;

namespace ProjectEuler.Problems;

public sealed class Problem0024 : ProblemBase
{
    private const string Characters = "0123456789";
    private const int PermutationNumber = 1_000_000;

    public override string Title => "Lexicographic Permutations";

    public override string Solve()
    {
        var remainingCharacters = Characters.ToList();
        var factorials = new int[Characters.Length];
        factorials[0] = 1;
        for (var i = 1; i < factorials.Length; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var permutationIndex = PermutationNumber - 1;
        var permutation = new System.Text.StringBuilder(Characters.Length);
        while (remainingCharacters.Count > 0)
        {
            var factorialBlockSize = factorials[remainingCharacters.Count - 1];
            var characterIndex = permutationIndex / factorialBlockSize;
            permutationIndex %= factorialBlockSize;

            permutation.Append(remainingCharacters[characterIndex]);
            remainingCharacters.RemoveAt(characterIndex);
        }

        return permutation.ToString();
    }
}


