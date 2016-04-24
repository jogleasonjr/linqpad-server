using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LinqpadServer.WebApi.Controllers
{
    [RoutePrefix("api/snippet")]
    public class SnippetController : ApiController
    {
        // this lists snippets
        private readonly SnippetRepo _repo = new SnippetRepo(/* OVERRIDE DEFAULT DIR HERE*/);

        // this executes snippets
        private readonly LpRunner _runner = new LpRunner();

        /// <summary>
        /// New instance of snippet controller
        /// </summary>
        public SnippetController()
        {

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
