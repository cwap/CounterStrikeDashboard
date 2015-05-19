using CounterStrikeDashboard.Core.CsEvents.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.Events
{
    [DataContract]
    public class RoundWinEvent : EventBase
    {
        [DataMember]
        public string Team { get; set; }

        [DataMember]
        public string WinType { get; set; }
    }
}
