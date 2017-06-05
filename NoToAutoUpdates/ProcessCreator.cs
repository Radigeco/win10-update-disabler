using System.Diagnostics;

namespace UpdateControl
{
    public class ProcessCreator
    {
        public Process CreateService(string command)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = "/C " + command
            };
            process.StartInfo = startInfo;
            return process;
        }
    }
}