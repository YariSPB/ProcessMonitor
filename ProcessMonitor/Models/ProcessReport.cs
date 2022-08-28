using System;
using System.Collections.Generic;

namespace ProcessMonitor.Models
{
   public  class ProcessReport
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
