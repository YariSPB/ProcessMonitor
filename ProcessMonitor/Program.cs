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
                HttpClient client = new HttpClient();
                var response = client.GetAsync(baseAddress + "/api/process/").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();

            }
        }
    }
}
