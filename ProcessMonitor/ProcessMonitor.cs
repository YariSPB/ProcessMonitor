using System;
using System.Collections.Generic;
using ProcessMonitor.Models;
using System.Diagnostics;
using System.Linq;

namespace ProcessMonitor
{
    class ProcessMonitor
    {
        //stackoverflow.com/questions/278071/how-to-get-the-cpu-usage-in-c
        public IEnumerable<ProcessInfo> GetRunningProcesses()
        {
            Process[] processes = Process.GetProcesses();
            List<ProcessInfo> processInfo = new List<ProcessInfo>();
            foreach (Process process in processes)
            {
                var processRecord = new ProcessInfo
                {
                    Id = process.Id,
                    Name = process.ProcessName,
                    MemoryMbyte = process.WorkingSet64 / 1024/1024
                };
                processInfo.Add(processRecord);

            }

            return processInfo.OrderByDescending(o => o.MemoryMbyte).ToList();

        }
    }
}
