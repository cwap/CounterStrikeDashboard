using Microsoft.AspNet.SignalR.Hubs;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.Bootstrap
{
    class SignalRErrorHandler : HubPipelineModule
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            _log.Error("SignalR Exception " + exceptionContext.Error.Message);
            if (exceptionContext.Error.InnerException != null)
            {
                _log.Error("  => Inner Exception " + exceptionContext.Error.InnerException.Message);
            }
            base.OnIncomingError(exceptionContext, invokerContext);

        }
    }
}
