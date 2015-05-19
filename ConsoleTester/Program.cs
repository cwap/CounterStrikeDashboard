using CounterStrikeDashboard.Communication;
using CounterStrikeDashboard.Core;
using CounterStrikeDashboard.Core.CsEvents.Impl;
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
            var eventManager = new EventManager();

            filesource.OnNewEvent += eventManager.HandleEvent;
            filesource.Run();

            //Timer t = new Timer(new TimerCallback(x => stateKeeper.PrintScores()), null, 0, 5000);

            //var application = new Application(server, eventManager);
            //application.Start();

            Console.ReadKey();
        }
    }
}
