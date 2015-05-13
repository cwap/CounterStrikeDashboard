using Nancy;
using Nancy.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
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
    }
}
