using CounterStrikeDashboard.Server.Bootstrap;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using Nancy.TinyIoc;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard
{
    class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.HubPipeline.AddModule(new SignalRErrorHandler());

            var container = new TinyIoCContainer();

            app.MapSignalR(new HubConfiguration()
                {
                    //Resolver = new TinyIoCDependencyResolver(container)
                });
                
            app.UseNancy(new Nancy.Owin.NancyOptions()
                {
                    Bootstrapper = new NancyBootstrapper(container)
                });
        }
    }
}
