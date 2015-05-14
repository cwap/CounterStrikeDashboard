using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class MapStartedEventHandler : IEventHandler
    {
        //Template: Started map "de_falling" (CRC "875406954")


        public void Execute(Impl.EventParserHelpers.ParsedEvent evt, StateKeeper stateManager)
        {
            throw new NotImplementedException();
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.StartsWith("Started map ");
        }
    }
}
