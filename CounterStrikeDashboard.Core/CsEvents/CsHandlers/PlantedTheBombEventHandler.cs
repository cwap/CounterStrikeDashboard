
using CounterStrikeDashboard.Core.CsEvents.Events;
using CounterStrikeDashboard.Core.Services.CsEvents.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class PlantedTheBombEventHandler : ICsEventHandler
    {
        //Template: "[P*D]L33t B0t (100)<1><BOT><TERRORIST>" triggered "Planted_The_Bomb"
        private const string POSTFIX = " \"Planted_The_Bomb\"";
        private const string SPLIT = " triggered ";

        public event Action<PlantedBombEvent> OnPlayerPlantedTheBomb;

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt)
        {
            var splittedEvent = evt.Event.Split(new string[] { SPLIT }, StringSplitOptions.RemoveEmptyEntries);
            var playerString = splittedEvent[0];

            string playerUid;
            string playerName;
            string playerTeam;

            PlayerParser.ParsePlayer(playerString, out playerName, out playerUid, out playerTeam);

            if (OnPlayerPlantedTheBomb != null)
            {
                OnPlayerPlantedTheBomb(new PlantedBombEvent()
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
            return evt.Event.EndsWith(POSTFIX);
        }
    }
}
