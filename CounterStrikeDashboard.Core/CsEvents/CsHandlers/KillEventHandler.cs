
using CounterStrikeDashboard.Core.CsEvents.Events;
using CounterStrikeDashboard.Core.CsEvents.Impl.EventParserHelpers;
using CounterStrikeDashboard.Core.Services.CsEvents.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class KillEventHandler : ICsEventHandler
    {
        // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>" killed "[POD]Pissed Off (100)<7><BOT><CT>" with "ak47"

        public event Action<KillEvent> OnPlayerKilled;

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.Contains("\" killed \"");
        }

        public void Execute(ParsedEvent evt)
        {
            var splitted = evt.Event.Split(new string[] { " killed " }, StringSplitOptions.RemoveEmptyEntries);
            var killerString = splitted[0];            

            var rightSplitted = splitted[1].Split(new string[] { " with " }, StringSplitOptions.RemoveEmptyEntries);
            var deadManString = rightSplitted[0];
            string weapon = rightSplitted[1].Substring(1, rightSplitted[1].Length - 2);

            string killerName;
            string killerUid;
            string killerTeam;

            string deadManName;
            string deadManUid;
            string deadManTeam;

            PlayerParser.ParsePlayer(killerString, out killerName, out killerUid, out killerTeam);
            PlayerParser.ParsePlayer(deadManString, out deadManName, out deadManUid, out deadManTeam);

            if (OnPlayerKilled != null)
                OnPlayerKilled(new KillEvent()
                    {
                        EventTime = evt.DateTime,
                        OriginalEvent = evt.Event,
                        Killer = new Player()
                        {
                            PlayerName = killerName,
                            Team = killerTeam,
                            Uid = killerUid
                        },
                        Dead = new Player()
                        {
                            PlayerName = deadManName,
                            Team = deadManTeam,
                            Uid = deadManUid
                        },
                        Weapon = weapon
                    });
        }
    }
}
