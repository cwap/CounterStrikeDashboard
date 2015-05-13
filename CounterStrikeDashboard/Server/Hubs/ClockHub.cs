using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.Hubs
{
    public class ClockHub : Hub
    {
        public void UpdateClock()
        {
            Clients.All.updateClock(DateTime.Now.ToString());
        }

        public void SendMessage(string message)
        {
            Clients.All.sendMessage(message);
        }
    }
}