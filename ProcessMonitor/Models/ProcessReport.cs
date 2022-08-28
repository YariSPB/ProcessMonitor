using System;
using System.Collections.Generic;

namespace ProcessMonitor.Models
{
    // ProcessReport is a container for collected running processes data.
    // ReportToken is uniquelly assigned to each new report to be able to distinguish between versions.
    public class ProcessReport
    {
        public string ReportToken { get; }
        public IEnumerable<ProcessInfo> ProcessRecords { get; }
    public ProcessReport(IEnumerable<ProcessInfo> processRecords)
        {
            ReportToken= Guid.NewGuid().ToString();
            ProcessRecords = processRecords;
        }
    }
}
