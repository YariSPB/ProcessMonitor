using System;
using System.Collections.Generic;

namespace ProcessMonitor.Models
{
   public  class ProcessReport
    {
        public Guid ReportToken { get; }
        public IEnumerable<ProcessInfo> ProcessRecords { get; }
    public ProcessReport(IEnumerable<ProcessInfo> processRecords)
        {
            ReportToken= Guid.NewGuid();
            ProcessRecords = processRecords;
        }
    }
}
