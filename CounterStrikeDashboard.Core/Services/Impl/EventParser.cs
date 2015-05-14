using CounterStrikeDashboard.Core.Model;
using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl
{
    public class EventParser : IEventParser
    {
        public ParsedEvent ParseEvent(string evt)
        {
            evt = CleanEvent(evt);

            if (evt == null)
                return null;

            const int DATETIME_LENGTH = 21;
            const int SPAM_LENGTH = 2;
            var datepart = evt.Substring(0, DATETIME_LENGTH);
            evt = evt.Substring(DATETIME_LENGTH + SPAM_LENGTH);

            var result = new ParsedEvent()
            {
                DateTime = DateTime.ParseExact(datepart, "MM/dd/yyyy - HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                Event = evt
            };

            return result;
        }

        private string CleanEvent(string evt)
        {
            const int OFFSET = 10;

            if (evt.Length <= OFFSET)
                return null;

            return evt.Substring(OFFSET).Trim();
        }     
    }
}
