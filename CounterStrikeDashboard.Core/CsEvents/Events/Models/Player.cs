using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.Events
{
    [DataContract]
    public class Player
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
        public string PlayerName { get; set; }

        [DataMember]
        public string Uid { get; set; }

        [DataMember]
        public string Team { get; set; }
    }
}
