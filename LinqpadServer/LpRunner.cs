using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqpadServer
{
    /// <summary>
    /// Wraps lprun.exe
    /// </summary>
    public class LpRunner
    {
        private const string LprunExe = "lprun";

        public IEnumerable<string> Run(FileInfo file, string arguments = "")
        {
            CheckLprunIsInPath();

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = LprunExe,
                    Arguments = $"\"{file.FullName}\" {arguments}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            var lines = new List<string>();
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                var line = proc.StandardOutput.ReadLine();
                yield return line;
            }
        }

        public void CheckLprunIsInPath()
        {
            if (!Environment.GetEnvironmentVariable("PATH").Contains("LINQPad"))
            {
                throw new ApplicationException("LinqPad is not installed in the PATH environment variable. Please (re)install LinqPad and enable the option to \"Add lprun.exe to system PATH\".");
            }
        }
    }
}
