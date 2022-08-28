
using System.Collections.Generic;
using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    public class ProcessController : ApiController
    {
        public ProcessReport Get()
        {
            var processReport = ProcessReportingService.Instance.GetProcessesReport();
            return processReport;
        }
    }
}
