using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.Events.Models
{
    [DataContract]
    public class EventBase
    {
        [DataMember(Name = "__name__")]
        public string ClassName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        [DataMember]
        public DateTime EventTime { get; set; }

        [DataMember]
        public string OriginalEvent { get; set; }
    }
}
