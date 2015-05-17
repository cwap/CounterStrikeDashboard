using CounterStrikeDashboard.Core.CsEvents.Impl.EventParserHelpers;
using CounterStrikeDashboard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents
{
    public interface IEventParser
    {
        ParsedEvent ParseEvent(string evt);
    }
}
