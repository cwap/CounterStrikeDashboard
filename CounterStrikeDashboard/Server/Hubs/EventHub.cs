using CounterStrikeDashboard.Core.CsEvents;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.Hubs
{
    public class EventHub : Hub
    {
        public void Lol(string msg)
        {
            this.Clients.All.lol(msg);
        }
    }
}
