using System.Reflection;

namespace ProjectEuler.Core;

public static class EmbeddedData
{
    /// <summary>Finds an embedded resource whose name ends with <paramref name="fileName"/>.</summary>
    public static string ReadAllText(Assembly assembly, string fileName)
    {
        var resource = assembly.GetManifestResourceNames()
            .SingleOrDefault(n => n.EndsWith("." + fileName, StringComparison.OrdinalIgnoreCase) ||
                                  n.Equals(fileName, StringComparison.OrdinalIgnoreCase))
            ?? throw new FileNotFoundException(
                $"Embedded resource '{fileName}' not found. Put it in Data/ and make sure it is an EmbeddedResource.");

        using var stream = assembly.GetManifestResourceStream(resource)!;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
