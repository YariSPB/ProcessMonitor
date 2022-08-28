using System;
using ProcessMonitor.Models;
using System.Timers;
using System.Threading;
using System.Configuration;

namespace ProcessMonitor
{
    // ProcessReportingService manages a collection of processes' monitoring information.
    // It is a Singleton which is designed to support concurrent use of a shared resource by multiple Requests. Dependency injection not used for sake of brevity.
    // Consumer-Producer pattern separates generation and consumption of process monitoring information and supports concurrent Read/Write operations.
    public class ProcessReportingService
    {
        public readonly static ProcessReportingService Instance = new ProcessReportingService();

        // ReaderWriterLockSlim is used to provide concurrent Read/Write access to a Report Repository
        private ReaderWriterLockSlim reportLock = new ReaderWriterLockSlim();

        // (Report Repository) latestProcessReport holds only the latest version of a ProcessReport.
        private ProcessReport latestProcessReport;
        private readonly int updateFrequency;

        // ProcessMonitor builds actual Process Reports. 
        private ProcessMonitor processMonitor;

        // report version counter, auxiliary information
        private int count = 0;

        // private Singleton constructor
        private ProcessReportingService()
        {
            updateFrequency = Int32.Parse(ConfigurationManager.AppSettings["reportUpdateFrequencySecond"]);
            processMonitor = new ProcessMonitor();
            MonitorProcesses();
        }

        // Provides with the latest available version of a processes' report.
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

        // Generates new ProcessReport and replaces the previous version.  
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

        // A method to initiate a reccuring task for generating a ProcessReport
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
