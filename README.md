# Project Euler in C#

My C# solutions to [Project Euler](https://projecteuler.net) problems.

> Project Euler asks that answers to problems past #100 are not published. This repo therefore
> stores only SHA-256 hashes of answers (`tests/ProjectEuler.Tests/answers.json`), never the answers themselves.

## Requirements

- .NET 8 SDK

## Run

```bash
dotnet run --project src/ProjectEuler.Runner -- 1          # one problem
dotnet run --project src/ProjectEuler.Runner -- 1-50       # a range
dotnet run --project src/ProjectEuler.Runner -- --all      # everything, with timings
dotnet test                                                # verify answers against stored hashes
```

Use `-c Release` for realistic timings.

## Add a new problem

1. Copy `src/ProjectEuler.Problems/Problem0001.cs` to `ProblemNNNN.cs` (4-digit, zero-padded) and rename the class.
   The class name determines the problem number; there is no registration step.
2. Set `Title` and implement `Solve()`, returning the answer as a string.
3. Run `dotnet run --project src/ProjectEuler.Runner -- --hash NNNN` and add the printed line to
   `tests/ProjectEuler.Tests/answers.json` once Project Euler confirms the answer.
4. If the problem needs an input file, drop it in `src/ProjectEuler.Problems/Data/` and read it with `ReadData("file.txt")`.

## Benchmark

```bash
EULER_PROBLEMS=1,2,3 dotnet run -c Release --project benchmarks/ProjectEuler.Benchmarks
```

## Layout

| Path | Purpose |
|---|---|
| `src/ProjectEuler.Core` | `IProblem`, registry, hashing, shared maths utilities (primes, number theory, digits) |
| `src/ProjectEuler.Problems` | One class per problem, plus embedded input data |
| `src/ProjectEuler.Runner` | Console runner |
| `tests/ProjectEuler.Tests` | Hash-based answer tests + utility unit tests |
| `benchmarks/ProjectEuler.Benchmarks` | BenchmarkDotNet harness |
| `docs/notes` | Optional write-ups |

## Progress

| # | Title | Time |
|---|---|---|
| 1 | Multiples of 3 or 5 | |
| 2 | Even Fibonacci Numbers | |
| 3 | Largest Prime Factor | |
