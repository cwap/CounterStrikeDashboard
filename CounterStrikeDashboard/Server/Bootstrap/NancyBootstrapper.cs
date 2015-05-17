using ConsoleTester;
using CounterStrikeDashboard.Communication;
using CounterStrikeDashboard.Core;
using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents;
using CounterStrikeDashboard.Core.CsEvents.Impl;
using CounterStrikeDashboard.Core.Infrastructure;
using CounterStrikeDashboard.Core.Infrastructure.Sinks;
using CounterStrikeDashboard.Infrastructure;
using CounterStrikeDashboard.Server.CsEventHandlers;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.Bootstrap
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();
        
        private TinyIoCContainer _container;

        public NancyBootstrapper(TinyIoCContainer container)
        {
            this._container = container;
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new RootPathProvider(); }
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);

            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("app", "App"));
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("views", "Views"));
        }

        protected override TinyIoCContainer GetApplicationContainer()
        {
            return _container;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.OnError += (ctx, ex) =>
            {
                _log.Error("Global error in Nancy.", ex);
                return null;
            };

            var filesource = new ConsoleTester.FileEventSource();
            var server = new CommunicationServer();

            var eventParser = new EventParser();
            var eventManager = new EventManager(eventParser, new List<ICsEventSink>() { new ConsoleSink(), new FileSink() });
            var scoreKeeper = new ScoreKeeper(eventManager);

            var webSocketMediator = new WebSocketMediator(eventManager);

            var application = new Application(server, eventManager);
            application.Start();

            filesource.OnNewEvent += eventManager.HandleEvent;

            container.Register<IEventManager>(eventManager);
            container.Register<ScoreKeeper>(scoreKeeper);
            container.Register<WebSocketMediator>(webSocketMediator);
            container.Register<Application>(application);
            container.Register<FileEventSource>(filesource); // TODO - Remove and clean up

            base.ApplicationStartup(container, pipelines);

            filesource.Run();
        }
    }
}
