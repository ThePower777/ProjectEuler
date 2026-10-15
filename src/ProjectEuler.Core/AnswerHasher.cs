using System.Security.Cryptography;
using System.Text;

namespace ProjectEuler.Core;

/// <summary>
/// Project Euler asks people not to publish answers. We store only SHA-256 hashes of the
/// answers (see tests/ProjectEuler.Tests/answers.json) and compare hashes instead.
/// </summary>
public static class AnswerHasher
{
    public static string Hash(string answer) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(answer))).ToLowerInvariant();
}
