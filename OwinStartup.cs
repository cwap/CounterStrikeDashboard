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
            app.MapSignalR().UseNancy();
        }
    }
}
