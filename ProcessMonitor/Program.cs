using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;


namespace ProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://127.0.0.1:8080";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {           
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();

            }
        }
    }
}
