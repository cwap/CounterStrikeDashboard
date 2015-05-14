using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class KillEventHandler : IEventHandler
    {
        public bool Matches(ParsedEvent evt)
        {
            return true;
        }

        public void Execute(ParsedEvent evt, StateKeeper stateManager)
        {

        }
    }
}
