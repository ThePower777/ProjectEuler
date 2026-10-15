using BenchmarkDotNet.Attributes;
using ProjectEuler.Core;
using ProjectEuler.Problems;

namespace ProjectEuler.Benchmarks;

[MemoryDiagnoser]
public class ProblemBenchmarks
{
    private static readonly ProblemRegistry Registry =
        ProblemRegistry.FromAssembly(typeof(AssemblyMarker).Assembly);

    /// <summary>Set EULER_PROBLEMS=1,2,3 to benchmark a subset; default is every solved problem.</summary>
    public static IEnumerable<int> Numbers()
    {
        var env = Environment.GetEnvironmentVariable("EULER_PROBLEMS");
        return string.IsNullOrWhiteSpace(env)
            ? Registry.Numbers
            : env.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse);
    }

    [ParamsSource(nameof(Numbers))]
    public int Number { get; set; }

    [Benchmark]
    public string Solve() => Registry.Get(Number).Solve();
}
