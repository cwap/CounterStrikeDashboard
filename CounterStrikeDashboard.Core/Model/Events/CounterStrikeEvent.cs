using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model.Events
{
    public class CounterStrikeEvent
    {
        public CounterStrikeEvent(string originalMessage)
        {
            this.OriginalMessage = originalMessage;
        }

        public string OriginalMessage { get; private set; }
    }
}
