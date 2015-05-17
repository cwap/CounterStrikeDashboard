using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents.Impl.EventParserHelpers;
using CounterStrikeDashboard.Core.Services.CsEvents.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class JoinedTeamEventHandler : ICsEventHandler
    {
        //Template: "[P*D]Chris_Rock (100)<3><BOT><>" joined team "TERRORIST"

        private const string EVENT_STRING = "\" joined team \"";

        public event Action<DateTime, string, string> OnPlayerAdded;
        public event Action<DateTime, string, string, string> OnJoinedTeam;

        public void Execute(ParsedEvent evt)
        {
            var splittedEvent = evt.Event.Split(new string[] { EVENT_STRING }, StringSplitOptions.RemoveEmptyEntries);
            var playerString = splittedEvent[0];
            var teamString = splittedEvent[1].Substring(0, splittedEvent[1].Length - 1);

            string playerUid;
            string playerName;

            PlayerParser.ParsePlayer(playerString, out playerName, out playerUid);

            if (OnPlayerAdded != null)
                OnPlayerAdded(evt.DateTime, playerUid, playerName);
            if (OnJoinedTeam != null)
                OnJoinedTeam(evt.DateTime, playerUid, playerName, teamString == "TERRORIST" ? "T" : "CT");
        }

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.Contains(EVENT_STRING);
        }
    }
}
