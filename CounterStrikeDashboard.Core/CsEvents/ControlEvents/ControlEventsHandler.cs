using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.ControlEvents
{
    public class ControlEventsHandler
    {
        public event Action OnControlReset;

        internal void FireResetEvent()
        {
            if (OnControlReset != null)
                OnControlReset();
        }
    }
}
