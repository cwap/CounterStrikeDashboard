using CounterStrikeDashboard.Communication;
using CounterStrikeDashboard.Core;
using CounterStrikeDashboard.Core.Services;
using CounterStrikeDashboard.Core.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesource = new FileEventSource();
            var server = new CommunicationServer();
            var stateKeeper = new StateKeeper();
            var eventManager = new EventManager(stateKeeper);

            filesource.OnNewEvent += eventManager.HandleEvent;
            filesource.Run();

            //var application = new Application(server, eventManager);
            //application.Start();

            Console.ReadKey();
        }
    }
}
