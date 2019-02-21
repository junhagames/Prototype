using System;
using Nancy.Hosting.Self;

namespace Test.Main
{
    class StartServer
    {
        static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            Console.WriteLine(hostConfigs);
            Uri uri = new Uri("http://127.0.0.1:8080");
            using (var host = new NancyHost(hostConfigs, uri))
            {
                host.Start();
                Console.WriteLine("http://127.0.0.1:8080 hosting started!");
                Console.ReadLine();
            }
        }
    }
}
