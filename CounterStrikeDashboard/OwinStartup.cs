using CounterStrikeDashboard.Server.Bootstrap;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using Nancy.TinyIoc;
using Newtonsoft.Json;
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

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();
            var serializer = JsonSerializer.Create(settings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);
                
            app.UseNancy(new Nancy.Owin.NancyOptions()
                {
                    Bootstrapper = new NancyBootstrapper(container)
                });
        }
    }
}
