using System.Collections.Generic;
using ProcessMonitor.Models;
using System.Diagnostics;
using System.Linq;

namespace ProcessMonitor
{
    // ProcessMonitor is directly responsible for accessing the System and generating Running Processes' Reports.
    class ProcessMonitor
    {
        // GetProcessReport collects relevant data about running processes and generates a Process Report.
        public ProcessReport GetProcessReport()
        {
            Process[] processes = Process.GetProcesses();
            List<ProcessInfo> processInfo = new List<ProcessInfo>();
            foreach (Process process in processes)
            {
                var processRecord = new ProcessInfo
                {
                    Id = process.Id,
                    Name = process.ProcessName,
                    MemoryMbyte = (double) process.WorkingSet64 / 1024 / 1024
                };
                processInfo.Add(processRecord);
            }
            ProcessReport processReport = new ProcessReport(processInfo.OrderByDescending(o => o.MemoryMbyte).ToList());
            return processReport;
        }
    }
}
