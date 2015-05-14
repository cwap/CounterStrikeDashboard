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
        private const string PREFIX = "Started map \"";

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt, StateKeeper stateManager)
        {
            string mapName = GetMapName(evt.Event);
            stateManager.StartNewMap(mapName);
        }

        private string GetMapName(string p)
        {
            var mapPostFix = p.Substring(PREFIX.Length);
            return mapPostFix.Substring(0, mapPostFix.IndexOf("\""));
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.StartsWith(PREFIX);
        }
    }
}
