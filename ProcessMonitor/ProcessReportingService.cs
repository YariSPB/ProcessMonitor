using System;
using System.Collections.Concurrent;
using System.Collections.Generic; 
using ProcessMonitor.Models;
using System.Timers;

namespace ProcessMonitor
{
    public class ProcessReportingService
    {
        public readonly static ProcessReportingService Instance = new ProcessReportingService();
        private ConcurrentStack<IEnumerable<ProcessInfo>> processReportStack = new ConcurrentStack<IEnumerable<ProcessInfo>>();
        private int updateFrequency = 2;
        private ProcessMonitor processMonitor;
        int count = 0;

        private ProcessReportingService()
        {
            processMonitor = new ProcessMonitor();
            MonitorProcesses();
        }

        public IEnumerable<ProcessInfo> GetRunningProcesses()
        {
            IEnumerable<ProcessInfo> result;
            processReportStack.TryPeek(out result);
            return result;
        }

        private void MonitorProcesses()
        {
            SetTimer();
        }

        private void FetchProcesses(Object source, ElapsedEventArgs e)
        {
            ++count;
            ProcessInfo process1 = new ProcessInfo { Id = 1, Name = "V. "+ count + " soup1" };
            ProcessInfo process2 = new ProcessInfo { Id = 2, Name = "V. "+ count + " soup2" };
            // var result = new ProcessInfo[] { process1, process2 };
            var result = processMonitor.GetRunningProcesses();
            processReportStack.Clear();
            processReportStack.Push(result);
            Console.WriteLine("version " + count);

        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            var aTimer = new Timer(updateFrequency*1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += FetchProcesses;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}
