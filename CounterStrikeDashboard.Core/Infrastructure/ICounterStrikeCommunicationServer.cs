using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Infrastructure
{
    public interface ICounterStrikeCommunicationServer : ICsEventSource
    {
        bool IsRunning { get; }        
        event Action OnClosed;
        event Action<Exception> OnError;
        int Port { get; }
        void Start(int port);
        void Stop();
    }
}
