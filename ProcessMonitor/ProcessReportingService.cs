using System;
using ProcessMonitor.Models;
using System.Timers;
using System.Threading;
using System.Configuration;

namespace ProcessMonitor
{
    public class ProcessReportingService
    {
        public readonly static ProcessReportingService Instance = new ProcessReportingService();
        private ReaderWriterLockSlim reportLock = new ReaderWriterLockSlim();
        private ProcessReport latestProcessReport;

        private readonly int updateFrequency;
        private ProcessMonitor processMonitor;
        int count = 0;

        private ProcessReportingService()
        {
            updateFrequency = Int32.Parse(ConfigurationManager.AppSettings["reportUpdateFrequencySecond"]);
            processMonitor = new ProcessMonitor();
            MonitorProcesses();
        }


        public ProcessReport ReadLatestProcessesReport(string prevReportToken)
        {
            ProcessReport processReport;
            reportLock.EnterReadLock();
            try
            {
                if (latestProcessReport == null || latestProcessReport.ReportToken == prevReportToken)
                {
                    processReport = null;
                }
                else
                {
                    processReport = latestProcessReport;
                }
            }
            finally
            {
                reportLock.ExitReadLock();
            }

            return processReport;       
        }

        private void MonitorProcesses()
        {
            SetTimer();
        }


        private void WriteProcessesReport(Object source, ElapsedEventArgs e)
        {
            var newestProcessReport = processMonitor.GetProcessReport();
            reportLock.EnterWriteLock();
            try
            {
                latestProcessReport = newestProcessReport;
                ++count;
                Console.WriteLine("New version of process report available: " + count);
            }
            finally
            {
                reportLock.ExitWriteLock();
            }

        }


        private void SetTimer()
        {
            // Create a timer with a two second interval.
            var aTimer = new System.Timers.Timer(updateFrequency*1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += WriteProcessesReport;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}
