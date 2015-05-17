using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class MapStartedEventHandler : ICsEventHandler
    {
        //Template: Started map "de_falling" (CRC "875406954")
        private const string PREFIX = "Started map \"";

        public event Action<DateTime, string> OnNewMapStarted;

        public void Execute(ParsedEvent evt)
        {
            string mapName = GetMapName(evt.Event);
            if (OnNewMapStarted != null)
                OnNewMapStarted(evt.DateTime, mapName);
        }

        private string GetMapName(string p)
        {
            var mapPostFix = p.Substring(PREFIX.Length);
            return mapPostFix.Substring(0, mapPostFix.IndexOf("\""));
        }

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.StartsWith(PREFIX);
        }
    }
}
