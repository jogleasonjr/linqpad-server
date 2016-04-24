using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqpadServer
{
    /// <summary>
    /// Repository of Linqpad snippets
    /// </summary>
    public class SnippetRepo
    {
        private readonly DirectoryInfo _snippetDir;

        /// <summary>
        /// Default LinqPad snippet directory, e.g. C:\Users\{YOU}\Documents\LINQPad Queries
        /// </summary>
        private static DirectoryInfo DefaultSnippetDir { get; } = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Documents\Linqpad Queries"));

        /// <summary>
        /// Create a repo with the specified starting directory
        /// </summary>
        /// <param name="dir"></param>
        public SnippetRepo(DirectoryInfo snippetDir)
        {
            if (snippetDir == null)
                throw new ArgumentNullException(nameof(snippetDir));

            if(!snippetDir.Exists)
            {
                throw new DirectoryNotFoundException(snippetDir.FullName);
            }

            _snippetDir = snippetDir;
        }

        /// <summary>
        /// Create a repo with the default LinqPad snippet directory, e.g. C:\Users\{YOU}\Documents\LINQPad Queries
        /// </summary>
        public SnippetRepo()
            : this(DefaultSnippetDir)
        {
        }

        /// <summary>
        /// Get a list of snippet files
        /// </summary>
        /// <returns>list of snippets files</returns>
        public IEnumerable<FileInfo> GetSnippetFiles()
        {
            return _snippetDir.GetFiles("*.linq");
        }

        /// <summary>
        /// Get a list of snippet names
        /// </summary>
        /// <returns>list of snippet namess</returns>
        public IEnumerable<string> GetSnippets()
        {
            return GetSnippetFiles().Select(f => Path.GetFileNameWithoutExtension(f.FullName));
        }

        /// <summary>
        /// Get runnable file object from the name sent to callers
        /// </summary>
        /// <param name="name">name of snippet you want</param>
        /// <returns>fileinfo of snippet</returns>
        public FileInfo GetFileFromName(string name)
        {
            return GetSnippetFiles().First(f => Path.GetFileNameWithoutExtension(f.FullName) == name);
        }
    }
}
