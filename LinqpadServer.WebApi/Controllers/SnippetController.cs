using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace LinqpadServer.WebApi.Controllers
{
    [RoutePrefix("api/snippet")]
    public class SnippetController : ApiController
    {
        /// <summary>
        /// Uncomment and modify this setting in Web.Config to override the default snippet directory
        /// </summary>
        private const string SnippetDefaultDirConfigurationKey = "SnippetDefaultDir";

        // this lists snippets
        private readonly SnippetRepo _repo;

        // this executes snippets
        private readonly LpRunner _runner = new LpRunner();

        /// <summary>
        /// New instance of snippet controller
        /// </summary>
        public SnippetController()
        {
            var snippetDir = ConfigurationManager.AppSettings[SnippetDefaultDirConfigurationKey];
            if (snippetDir != null)
            {
                _repo = new SnippetRepo(new DirectoryInfo(snippetDir));
            }
            else
            {
                _repo = new SnippetRepo();
            }
        }

        /// <summary>
        /// List the available snippets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public IEnumerable<string> List()
        {
            return _repo.GetSnippets();
        }

        /// <summary>
        /// Run a snippet with arguments
        /// </summary>
        /// <param name="snippet">Name of snippet to run</param>
        /// <param name="arguments">arguments</param>
        /// <returns>Standard output</returns>
        [HttpPost]
        [Route("run/{snippetName}")]
        public IEnumerable<string> RunArgs(string snippetName, [FromBody]string arguments)
        {
            var file = _repo.GetFileFromName(snippetName);
            return _runner.Run(file, arguments);
        }


        /// <summary>
        /// Run a snippet with no arguments
        /// </summary>
        /// <param name="snippet">Name of snippet to run</param>
        /// <returns>Standard output</returns>
        [HttpGet]
        [Route("run/{snippetName}")]
        public IEnumerable<string> Run(string snippetName)
        {
            var file = _repo.GetFileFromName(snippetName);
            return _runner.Run(file);
        }
    }
}
