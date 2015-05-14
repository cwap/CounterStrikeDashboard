using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class JoinedTeamEventHandler : IEventHandler
    {
        //Template: "[P*D]Chris_Rock (100)<3><BOT><>" joined team "TERRORIST"

        private const string EVENT_STRING = "\" joined team \"";

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt, StateKeeper stateManager)
        {
            var splittedEvent = evt.Event.Split(new string[] { EVENT_STRING }, StringSplitOptions.RemoveEmptyEntries);
            var playerString = splittedEvent[0];
            var teamString = splittedEvent[1].Substring(0, splittedEvent[1].Length - 1);

            string playerUid;
            string playerName;

            PlayerParser.ParsePlayer(playerString, out playerName, out playerUid);

            stateManager.AddPlayer(playerName, playerUid);
            stateManager.JoinTeam(playerUid, playerName, teamString == "TERRORIST" ? "T" : "CT");
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.Contains(EVENT_STRING);
        }
    }
}
