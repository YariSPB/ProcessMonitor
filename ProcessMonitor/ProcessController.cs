using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using ProcessMonitor.Models;

namespace ProcessMonitor
{
    class ProcessController : ApiController
    {
        private ProcessInfo process = new ProcessInfo { Id = 5, Name = "Tomato Soup" };

        public ProcessInfo Get()
        {

            return process;

            //return Ok(process);
        }
    }
}
