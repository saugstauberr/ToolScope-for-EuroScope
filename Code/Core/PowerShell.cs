using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class PowerShell
    {
        public void RunPowerShellScript()
        {

            var ps1File = "custom-ps.ps1";

            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
    }
}
