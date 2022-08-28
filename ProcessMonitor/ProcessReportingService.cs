using System;
using System.Collections.Concurrent;
using System.Collections.Generic; 
using ProcessMonitor.Models;
using System.Timers;
using System.Threading;

namespace ProcessMonitor
{
    public class ProcessReportingService
    {
        public readonly static ProcessReportingService Instance = new ProcessReportingService();
        private ConcurrentStack<ProcessReport> reportStack = new ConcurrentStack<ProcessReport>();
        //private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();

        private int updateFrequency = 2;
        private ProcessMonitor processMonitor;
        int count = 0;

        private ProcessReportingService()
        {
            processMonitor = new ProcessMonitor();
            MonitorProcesses();
        }

        public ProcessReport GetProcessesReport()
        {
            ProcessReport processReport;
            reportStack.TryPeek(out processReport);
            return processReport;
        }

        private void MonitorProcesses()
        {
            SetTimer();
        }

        private void FetchProcessesReport(Object source, ElapsedEventArgs e)
        {
            ++count;
            var result = processMonitor.GetProcessReport();
            reportStack.Clear();
            reportStack.Push(result);
            Console.WriteLine("version " + count);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            var aTimer = new System.Timers.Timer(updateFrequency*1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += FetchProcessesReport;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}
