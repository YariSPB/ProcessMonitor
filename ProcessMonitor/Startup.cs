using Owin;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProcessMonitor
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{processReportToken}",
                defaults: new { processReportToken = "abc" }
            );


            appBuilder.UseWebApi(config);
        }
    }
}