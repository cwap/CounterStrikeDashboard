﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class WinEventHandler : IEventHandler
    {
        public void Execute(Impl.EventParserHelpers.ParsedEvent evt, StateKeeper stateManager)
        {
            throw new NotImplementedException();
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
