using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Infrastructure;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server
{
    public class WebModule : NancyModule
    {
        public WebModule(ScoreKeeper scoreKeeper, EventHub eventHub)
        {            
            Get["/"] = p =>
            {
                return View["index.html"];
            };

            Get["/sessions"] = p =>
            {
                return Response.AsJson(scoreKeeper.Sessions);
            };
        }
    }
}
