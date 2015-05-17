using CounterStrikeDashboard.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class DefusedBombEventHandler : ICsEventHandler
    {
        //Template: 

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt)
        {
            throw new NotImplementedException();
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return false;
        }
    }
}
