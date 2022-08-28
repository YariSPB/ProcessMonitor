using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    // ProcessController implements an API for clients to collect latest available information about currently running processes. 
    public class ProcessController : ApiController
    {
        // Method Get provides with a latest Process Report. 
        // Meanwhile, it accepts a unique process report token as argument to distinguish a newer report from older version.
        public ProcessReport Get(string processReportToken)
        {
            var processReport = ProcessReportingService.Instance.ReadLatestProcessesReport(processReportToken);
            return processReport;
        }
    }
}
