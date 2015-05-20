
using CounterStrikeDashboard.Core.CsEvents.Events;
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

        public event Action<PlayerAddedEvent> OnPlayerAdded;
        public event Action<JoinedTeamEvent> OnJoinedTeam;

        public void Execute(ParsedEvent evt)
        {
            var splittedEvent = evt.Event.Split(new string[] { EVENT_STRING }, StringSplitOptions.RemoveEmptyEntries);
            var playerString = splittedEvent[0];
            var trimmedTeamString = splittedEvent[1].Trim('\n', '\0', ' ');
            var teamString = trimmedTeamString.Substring(0, trimmedTeamString.Length - 1);

            string playerUid;
            string playerName;
            string playerTeam;

            PlayerParser.ParsePlayer(playerString, out playerName, out playerUid, out playerTeam);

            if (OnPlayerAdded != null)
                OnPlayerAdded(new PlayerAddedEvent()
                {
                    EventTime = evt.DateTime,
                    OriginalEvent = evt.Event,
                    Player = new Player()
                    {
                        PlayerName = playerName,
                        Uid = playerUid,
                        Team = "NONE"
                    }
                });
            if (OnJoinedTeam != null)
                OnJoinedTeam(new JoinedTeamEvent()
                {
                    EventTime = evt.DateTime,
                    OriginalEvent = evt.Event,
                    Player = new Player()
                    {
                        PlayerName = playerName,
                        Uid = playerUid,
                        Team = String.IsNullOrEmpty(teamString) ? "NONE" : teamString == "TERRORIST" ? "T" : "CT",
                    },
                    Team = String.IsNullOrEmpty(teamString) ? "NONE" : teamString == "TERRORIST" ? "T" : "CT",
                });
        }

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.Contains(EVENT_STRING);
        }
    }
}
