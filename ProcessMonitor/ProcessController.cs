
using System.Collections.Generic;
using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    public class ProcessController : ApiController
    {

        public IEnumerable<ProcessInfo> Get()
        {
            var processList = ProcessReportingService.Instance.GetRunningProcesses();
            return processList;
        }
    }
}
