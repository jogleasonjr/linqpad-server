using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;

namespace LinqpadServer.Tests
{
    [TestClass]
    public class LpRunnerTests
    {
        [TestMethod]
        public void TestInvokeNoArgs()
        {
            var repo = new SnippetRepo(TestHelper.TestSnippetDir);
            var runner = new LpRunner();
            var testFile = repo.GetFileFromName("test");

            var output = runner.Run(testFile).ToArray();


            Assert.AreEqual(1, output.Length);
            Assert.AreEqual("Hello, world!", output[0]);
        }

        [TestMethod]
        public void TestInvokeWithArgs()
        {
            var repo = new SnippetRepo(TestHelper.TestSnippetDir);
            var runner = new LpRunner();
            var testFile = repo.GetFileFromName("test");

            var output = runner.Run(testFile, "one two").ToArray();

            Assert.AreEqual(3, output.Length);
            Assert.AreEqual("one", output[0]);
            Assert.AreEqual("two", output[1]);
            Assert.AreEqual("Hello, world!", output[2]);
        }
    }
}
