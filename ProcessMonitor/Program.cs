using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;


namespace ProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new HttpSelfHostConfiguration("http:\//localhost:8080");
            var config = new HttpSelfHostConfiguration("http://127.0.0.1:8080/");
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
