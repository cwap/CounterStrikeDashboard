using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model.Events
{
    public class KillEvent : TimedEvent
    {
        public KillEvent(string originalMessage)
            : base(originalMessage)
        {

        }

        public string Killer { get; set; }
        public string Died { get; set; }
        public string Weapon { get; set; }
    }
}
