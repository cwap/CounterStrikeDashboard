using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Infrastructure
{
    public interface ICsEventSource
    {
        event Action<string> OnNewEvent;
    }
}
