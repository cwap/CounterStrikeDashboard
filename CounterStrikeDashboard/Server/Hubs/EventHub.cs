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
        public void PlayerKilled(string killer, string deadperson)
        {
            this.Clients.All.PlayerKilled(killer, deadperson);
        }
    }
}
