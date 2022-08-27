
using System.Collections.Generic;
using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    public class ProcessController : ApiController
    {
        private ProcessInfo process1 = new ProcessInfo { Id = 1, Name = "Tomato Soup1" };
        private ProcessInfo process2 = new ProcessInfo { Id = 2, Name = "Tomato Soup2" };


        // GET api/values 
        public IEnumerable<ProcessInfo> Get()
        {
            var processLIst = new ProcessInfo[] { process1, process2 };

            return processLIst;
        }
    }
}
