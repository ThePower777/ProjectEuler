namespace ProjectEuler.Core;

public interface IProblem
{
    int Number { get; }

    string Title { get; }

    /// <summary>Computes the answer. Returned as a string so big or non-numeric answers fit.</summary>
    string Solve();
}
