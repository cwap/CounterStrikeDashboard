using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model.Events
{
    public class NullEvent : CounterStrikeEvent
    {
        public NullEvent(string originalMessage)
            : base(originalMessage)
        {

        }
    }
}
