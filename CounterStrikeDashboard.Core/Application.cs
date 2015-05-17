using CounterStrikeDashboard.Core.CsEvents;
using CounterStrikeDashboard.Core.Infrastructure;
using CounterStrikeDashboard.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core
{
    public class Application : IDisposable
    {
        public Application(ICounterStrikeCommunicationServer counterStrikeCommunicationServer, IEventManager eventManager)
        {
            this.CounterStrikeCommunicationServer = counterStrikeCommunicationServer;
            this.EventManager = eventManager;

            this.CounterStrikeCommunicationServer.OnNewEvent += this.EventManager.HandleEvent;
        }

        public ICounterStrikeCommunicationServer CounterStrikeCommunicationServer { get; private set; }
        public IEventManager EventManager { get; private set; }

        public void Dispose()
        {
            this.CounterStrikeCommunicationServer.OnNewEvent -= this.EventManager.HandleEvent;
        }

        public void Start()
        {
            CounterStrikeCommunicationServer.Start(27115);
        }
    }
}
