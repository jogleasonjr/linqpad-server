using System.IO;

namespace LinqpadServer.Tests
{
    public static class TestHelper
    {
        public static DirectoryInfo TestSnippetDir { get; } = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "snippets"));
    }
}
