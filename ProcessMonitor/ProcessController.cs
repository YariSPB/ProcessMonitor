
using System.Web.Http;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    public class ProcessController : ApiController
    {
        private ProcessInfo process = new ProcessInfo { Id = 5, Name = "Tomato Soup" };


        // GET api/values 
        public ProcessInfo Get()
        {
            return process;
        }
    }
}
