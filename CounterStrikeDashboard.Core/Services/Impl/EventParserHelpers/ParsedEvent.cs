using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers
{
    class ParsedEvent
    {
        public DateTime DateTime { get; set; }
        public string Left { get; set; }
        public string Action { get; set; }
        public string Right { get; set; }
        public string ContextAction { get; set; }
        public string ContextProperty { get; set; }
    }
}
