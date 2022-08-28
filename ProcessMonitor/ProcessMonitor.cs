using System.Collections.Generic;
using ProcessMonitor.Models;
using System.Diagnostics;
using System.Linq;

namespace ProcessMonitor
{
    class ProcessMonitor
    {
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
