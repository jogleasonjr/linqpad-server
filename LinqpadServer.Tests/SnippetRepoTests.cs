using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LinqpadServer.Tests
{
    [TestClass]
    public class SnippetRepoTests
    {
        [TestMethod]
        public void TestDefaultDir()
        {
            var repo = new SnippetRepo(TestHelper.TestSnippetDir);
            
            var files = repo.GetSnippets();

            Assert.AreEqual(1, files.Count());
        }

        [TestMethod]
        public void TestFileFromName()
        {
            var repo = new SnippetRepo(TestHelper.TestSnippetDir);
            
            var files = repo.GetSnippets();

            Assert.AreEqual(1, files.Count());
        }
    }
}
