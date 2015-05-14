using CounterStrikeDashboard.Core.Model;
using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services
{
    public interface IEventParser
    {
        ParsedEvent ParseEvent(string evt);
    }
}
