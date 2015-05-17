using CounterStrikeDashboard.Communication;
using CounterStrikeDashboard.Core;
using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents.Impl;
using CounterStrikeDashboard.Core.Services;
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
            var scoreKeeper = new ScoreKeeper(eventManager);

            filesource.OnNewEvent += eventManager.HandleEvent;
            filesource.Run();

            scoreKeeper.PrintScores();

            //Timer t = new Timer(new TimerCallback(x => stateKeeper.PrintScores()), null, 0, 5000);

            //var application = new Application(server, eventManager);
            //application.Start();

            Console.ReadKey();
        }
    }
}
