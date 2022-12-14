using System;
using System.Configuration;
using Microsoft.Owin.Hosting;


namespace ProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = ConfigurationManager.AppSettings["baseAddress"];

            // Start OWIN host with WEB API 2
            using (WebApp.Start<Startup>(url: baseAddress))
            {           
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
