using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers
{
    class EventInformation
    {
        public EventInformation(bool isContextEvent)
        {
            IsContextEvent = isContextEvent;
        }

        public bool IsContextEvent { get; set; }
    }
}
