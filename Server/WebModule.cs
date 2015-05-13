using CounterStrikeDashboard.Infrastructure;
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
        public WebModule()
        {
            Get["/status"] = parameters =>
            {
                var communicator = new CounterStrikeCommunicator();
                return communicator.GetStatus(new CounterStrikeCommunicatorConfiguration()
                {
                    Ip = "192.168.0.102",
                    Port = 27015,
                    RConPassword = "asd"
                });
            };

            Get["/"] = p =>
            {
                return View["index.html"];
            };
        }
    }
}
