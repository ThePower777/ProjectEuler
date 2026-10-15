using System.Text.Json;
using ProjectEuler.Core;
using ProjectEuler.Problems;
using Xunit;

namespace ProjectEuler.Tests;

public class ProblemTests
{
    private static readonly TimeSpan TimeLimit = TimeSpan.FromSeconds(60);

    private static readonly ProblemRegistry Registry =
        ProblemRegistry.FromAssembly(typeof(AssemblyMarker).Assembly);

    private static readonly Dictionary<int, string> Hashes = LoadHashes();

    public static TheoryData<int> ProblemNumbers()
    {
        var data = new TheoryData<int>();
        foreach (var n in Registry.Numbers)
        {
            data.Add(n);
        }

        return data;
    }

    [Theory]
    [MemberData(nameof(ProblemNumbers))]
    public async Task Produces_the_known_answer_within_the_time_limit(int number)
    {
        Assert.True(Hashes.TryGetValue(number, out var expectedHash),
            $"No hash recorded for problem {number}. Run: dotnet run --project src/ProjectEuler.Runner -- --hash {number}");

        var problem = Registry.Get(number);

        string answer;
        try
        {
            answer = await Task.Run(problem.Solve).WaitAsync(TimeLimit);
        }
        catch (TimeoutException)
        {
            Assert.Fail($"Problem {number} exceeded {TimeLimit.TotalSeconds:0}s.");
            return;
        }

        Assert.Equal(expectedHash, AnswerHasher.Hash(answer));
    }

    [Fact]
    public void Problem_numbers_match_class_names()
    {
        foreach (var p in Registry.All)
        {
            Assert.Equal($"Problem{p.Number:D4}", p.GetType().Name);
        }
    }

    [Fact]
    public void Hash_file_has_no_orphans()
    {
        foreach (var n in Hashes.Keys)
        {
            Assert.True(Registry.TryGet(n, out _), $"answers.json has an entry for problem {n} but no solution exists.");
        }
    }

    private static Dictionary<int, string> LoadHashes()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "answers.json");
        var raw = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path))!;
        return raw.ToDictionary(kv => int.Parse(kv.Key), kv => kv.Value);
    }
}
