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
        // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>" killed "[POD]Pissed Off (100)<7><BOT><CT>" with "ak47"

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.Contains("killed");
        }

        public void Execute(ParsedEvent evt, StateKeeper stateManager)
        {
            var splitted = evt.Event.Split(new string[] { " killed " }, StringSplitOptions.RemoveEmptyEntries);
            var killerString = splitted[0];            

            var rightSplitted = splitted[1].Split(new string[] { " with " }, StringSplitOptions.RemoveEmptyEntries);
            var deadManString = rightSplitted[0];

            string killerName;
            string killerUid;

            string deadManName;
            string deadManUid;
        }

        private void ParsePlayer(string playerString, out string player, out string uid)
        {
            // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>"

        }
    }
}
