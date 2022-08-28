﻿
using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    public class ProcessController : ApiController
    {
        public ProcessReport Get(string id)
        {
            var processReport = ProcessReportingService.Instance.ReadLatestProcessesReport(id);
            return processReport;
        }
    }
}
