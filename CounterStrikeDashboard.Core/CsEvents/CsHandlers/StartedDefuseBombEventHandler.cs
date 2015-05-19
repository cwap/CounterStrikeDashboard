
using CounterStrikeDashboard.Core.CsEvents.Events;
using CounterStrikeDashboard.Core.Services.CsEvents.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class StartedDefuseBombEventHandler : ICsEventHandler
    {
        //Template: "[POD]Pissed Off (100)<7><BOT><CT>" triggered "Begin_Bomb_Defuse_With_Kit"
        private const string EVENT_STRING = " \"Begin_Bomb_Defuse_\"";
        private const string SPLIT = " triggered ";

        public event Action<StartedDefuseBombEvent> OnPlayerStartedDefusingBomb;

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt)
        {
            var splittedEvent = evt.Event.Split(new string[] { SPLIT }, StringSplitOptions.RemoveEmptyEntries);
            var playerString = splittedEvent[0];

            string playerUid;
            string playerName;
            string playerTeam;

            PlayerParser.ParsePlayer(playerString, out playerName, out playerUid, out playerTeam);

            if (OnPlayerStartedDefusingBomb != null)
            {
                OnPlayerStartedDefusingBomb(new StartedDefuseBombEvent()
                {
                    EventTime = evt.DateTime,
                    OriginalEvent = evt.Event,
                    Player = new Player()
                    {
                        Name = playerName,
                        Uid = playerUid,
                        Team = playerTeam
                    }
                });
            }
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.Contains(EVENT_STRING);
        }
    }
}
