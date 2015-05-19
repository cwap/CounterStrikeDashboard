using CounterStrikeDashboard.Core;
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
        public WebModule(Application application, ConsoleTester.FileEventSource filesource) // TODO: Remove file eventsource
        {            
            Get["/"] = p =>
            {
                return View["index.html"];
            };

            Post["/sessions/reset"] = p =>
            {
                application.Reset();
                filesource.Run();
                return HttpStatusCode.OK;
            };
        }
    }
}
