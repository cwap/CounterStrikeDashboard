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
        public WebModule(Application application)
        {            
            Get["/"] = p =>
            {
                return View["index.html"];
            };

            Post["/sessions/reset"] = p =>
            {
                application.Reset();
                return HttpStatusCode.OK;
            };

            Post["/sessions/replayFile/{fileName}"] = p =>
            {
                string file = p.fileName;
                application.ReplayFile(file);
                return HttpStatusCode.OK;
            };
        }
    }
}
