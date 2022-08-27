using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessMonitor.Models;
using System.Diagnostics;

namespace ProcessMonitor
{
    class ProcessMonitor
    {
        public IEnumerable<ProcessInfo> GetRunningProcesses()
        {
            Process[] processes = Process.GetProcesses();
            List<ProcessInfo> processInfo = new List<ProcessInfo>();
            foreach (Process process in processes)
            {
                var processRecord = new ProcessInfo
                {
                    Id = process.Id,
                    Name = process.ProcessName
                };
                processInfo.Add(processRecord);
            }

            return processInfo;

        }
    }
}
