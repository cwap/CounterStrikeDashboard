using CounterStrikeDashboard.Infrastructure;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CounterStrikeDashboard
{
    class Program
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var url = "http://+:1337";

            using (WebApp.Start<OwinStartup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                
                //Console.WriteLine(cs.GetStatus(new CounterStrikeCommunicatorConfiguration() { Ip = "192.168.0.102", Port = 27015, RConPassword = "asd" }));
                //Console.WriteLine(cs.SetLogging(true, new CounterStrikeCommunicatorConfiguration() { Ip = "192.168.0.102", Port = 27015, RConPassword = "asd" }));

                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
