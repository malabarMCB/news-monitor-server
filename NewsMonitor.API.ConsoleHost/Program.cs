using System;
using Microsoft.Owin.Hosting;

namespace NewsMonitor.API.ConsoleHost
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<OwinStartup>(url: baseAddress))
            {
                Console.ReadLine();
            }
        }
    }
}