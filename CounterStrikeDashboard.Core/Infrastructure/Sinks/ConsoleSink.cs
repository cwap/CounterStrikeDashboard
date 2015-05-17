using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Infrastructure.Sinks
{
    public class ConsoleSink : ICsEventSink
    {
        public void HandleEvent(string csEvent)
        {
            Console.WriteLine(csEvent);
        }
    }
}
