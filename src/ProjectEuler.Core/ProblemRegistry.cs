using System.Collections.ObjectModel;
using System.Reflection;

namespace ProjectEuler.Core;

public sealed class ProblemRegistry
{
    private readonly SortedDictionary<int, IProblem> _problems;

    private ProblemRegistry(SortedDictionary<int, IProblem> problems) => _problems = problems;

    public IReadOnlyCollection<int> Numbers => new ReadOnlyCollection<int>([.. _problems.Keys]);

    public IEnumerable<IProblem> All => _problems.Values;

    public bool TryGet(int number, out IProblem problem) => _problems.TryGetValue(number, out problem!);

    public IProblem Get(int number) =>
        _problems.TryGetValue(number, out var p)
            ? p
            : throw new KeyNotFoundException($"Problem {number} has not been solved in this repo yet.");

    /// <summary>Discovers every concrete IProblem with a parameterless constructor in the given assembly.</summary>
    public static ProblemRegistry FromAssembly(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        var problems = new SortedDictionary<int, IProblem>();

        var types = assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false } && typeof(IProblem).IsAssignableFrom(t))
            .Where(t => t.GetConstructor(Type.EmptyTypes) is not null);

        foreach (var type in types)
        {
            var problem = (IProblem)Activator.CreateInstance(type)!;
            if (!problems.TryAdd(problem.Number, problem))
            {
                throw new InvalidOperationException(
                    $"Duplicate problem number {problem.Number}: {problems[problem.Number].GetType().Name} and {type.Name}.");
            }
        }

        return new ProblemRegistry(problems);
    }
}
