using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.ControlEvents
{
    public class ControlEventsHandler
    {
        public event Action OnControlReset;

        public event Action<String> OnFileReplayRequested;

        internal void FireResetEvent()
        {
            if (OnControlReset != null)
                OnControlReset();
        }

        internal void FireFileReplayRequested(String file)
        {
            if (OnFileReplayRequested != null)
            {
                OnFileReplayRequested(file);
            }
        }
    }
}
