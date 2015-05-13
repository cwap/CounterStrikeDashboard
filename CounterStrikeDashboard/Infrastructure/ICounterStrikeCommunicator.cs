using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Infrastructure
{
    public interface ICounterStrikeCommunicator
    {
        string GetStatus(CounterStrikeCommunicatorConfiguration configuration = null);
        string SetLogging(bool enabled, CounterStrikeCommunicatorConfiguration configuration = null);
    }
}
