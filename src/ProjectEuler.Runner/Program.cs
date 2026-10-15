using System.Diagnostics;
using ProjectEuler.Core;
using ProjectEuler.Problems;

const string Usage = """
    Usage:
      dotnet run --project src/ProjectEuler.Runner -- <n>          run one problem
      dotnet run --project src/ProjectEuler.Runner -- <a>-<b>      run a range
      dotnet run --project src/ProjectEuler.Runner -- --all        run everything
      dotnet run --project src/ProjectEuler.Runner -- --hash <n>   print the SHA-256 of problem n's answer
                                                                   (paste into tests/ProjectEuler.Tests/answers.json)
    """;

var registry = ProblemRegistry.FromAssembly(typeof(AssemblyMarker).Assembly);

if (args.Length == 0)
{
    Console.WriteLine(Usage);
    return 1;
}

if (args[0] == "--hash")
{
    if (args.Length < 2 || !int.TryParse(args[1], out var hashNumber) || !registry.TryGet(hashNumber, out var hp))
    {
        Console.Error.WriteLine("Unknown or missing problem number.");
        return 1;
    }

    Console.WriteLine($"\"{hp.Number}\": \"{AnswerHasher.Hash(hp.Solve())}\"");
    return 0;
}

List<int> selection;
if (args[0] == "--all")
{
    selection = [.. registry.Numbers];
}
else if (TryParseRange(args[0], out var from, out var to))
{
    selection = [.. registry.Numbers.Where(n => n >= from && n <= to)];
}
else
{
    Console.WriteLine(Usage);
    return 1;
}

if (selection.Count == 0)
{
    Console.WriteLine("No matching problems found.");
    return 1;
}

var results = new List<(IProblem Problem, string Answer, TimeSpan Elapsed)>();
Console.WriteLine($"{"#",4}  {"Title",-40} {"Answer",-24} {"Time",10}");
Console.WriteLine(new string('-', 82));

foreach (var number in selection)
{
    var problem = registry.Get(number);
    var sw = Stopwatch.StartNew();
    var answer = problem.Solve();
    sw.Stop();

    results.Add((problem, answer, sw.Elapsed));
    var shown = answer.Length > 24 ? answer[..21] + "..." : answer;
    Console.WriteLine($"{problem.Number,4}  {Truncate(problem.Title, 40),-40} {shown,-24} {Format(sw.Elapsed),10}");
}

if (results.Count > 1)
{
    Console.WriteLine();
    Console.WriteLine($"Total: {Format(TimeSpan.FromTicks(results.Sum(r => r.Elapsed.Ticks)))}");
    Console.WriteLine("Slowest:");
    foreach (var (Problem, Answer, Elapsed) in results.OrderByDescending(r => r.Elapsed).Take(3))
    {
        Console.WriteLine($"  {Problem.Number,4}  {Format(Elapsed)}");
    }
}

var over = results.Where(r => r.Elapsed > TimeSpan.FromMinutes(1)).ToList();
if (over.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine($"Warning: over the one-minute guideline: {string.Join(", ", over.Select(r => r.Problem.Number))}");
}

return 0;

static bool TryParseRange(string text, out int from, out int to)
{
    from = to = 0;
    var parts = text.Split('-', 2);
    if (parts.Length == 1)
    {
        return int.TryParse(parts[0], out from) && (to = from) == from;
    }

    return int.TryParse(parts[0], out from) && int.TryParse(parts[1], out to) && from <= to;
}

static string Format(TimeSpan t) =>
    t.TotalSeconds >= 1 ? $"{t.TotalSeconds:F2} s" : $"{t.TotalMilliseconds:F1} ms";

static string Truncate(string s, int max) => s.Length <= max ? s : s[..(max - 3)] + "...";
