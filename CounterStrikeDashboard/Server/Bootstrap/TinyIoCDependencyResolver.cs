using Microsoft.AspNet.SignalR;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.Bootstrap
{
    public class TinyIoCDependencyResolver : DefaultDependencyResolver
    {
        private readonly TinyIoCContainer m_Container;

        public TinyIoCDependencyResolver(TinyIoCContainer container)
        {
            m_Container = container;
        }

        public override object GetService(Type serviceType)
        {
            return m_Container.CanResolve(serviceType) ? m_Container.Resolve(serviceType) : base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var objects = m_Container.CanResolve(serviceType) ? m_Container.ResolveAll(serviceType) : new object[] { };
            return objects.Concat(base.GetServices(serviceType));
        }
    }
}
