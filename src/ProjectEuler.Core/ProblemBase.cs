namespace ProjectEuler.Core;

/// <summary>
/// Base class for solutions. Name the class ProblemNNNN (e.g. Problem0042) and the
/// number is derived automatically; override <see cref="Number"/> to break that convention.
/// </summary>
public abstract class ProblemBase : IProblem
{
    private const string Prefix = "Problem";

    public virtual int Number => ParseNumber(GetType());

    public abstract string Title { get; }

    public abstract string Solve();

    /// <summary>Reads an embedded text file from the problem assembly's Data folder.</summary>
    protected string ReadData(string fileName) => EmbeddedData.ReadAllText(GetType().Assembly, fileName);

    private static int ParseNumber(Type type)
    {
        var name = type.Name;
        if (name.StartsWith(Prefix, StringComparison.Ordinal) &&
            int.TryParse(name.AsSpan(Prefix.Length), out var n))
        {
            return n;
        }

        throw new InvalidOperationException(
            $"Cannot derive problem number from type name '{name}'. Name it ProblemNNNN or override Number.");
    }
}
