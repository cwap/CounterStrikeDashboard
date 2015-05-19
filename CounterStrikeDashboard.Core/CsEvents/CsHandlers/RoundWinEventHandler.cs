
using CounterStrikeDashboard.Core.CsEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.CsHandlers
{
    public class RoundWinEventHandler : ICsEventHandler
    {
        //Templates:
        /*
            Team "TERRORIST" triggered "Terrorists_Win" (CT "0") (T "2")
            Team "TERRORIST" triggered "Target_Bombed" (CT "0") (T "1")
            Team "CT" triggered "CTs_Win" (CT "1") (T "2")
            Team "CT" triggered "Bomb_Defused" (CT "11") (T "4")
            Team "CT" triggered "Target_Saved" (CT "1") (T "0")
         */

        private const string CT_TRIGGER = "Team \"CT\" triggered \"";
        private const string T_TRIGGER = "Team \"TERRORIST\" triggered \"";

        public event Action<RoundWinEvent> OnRoundEnded;

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt)
        {
            var team = evt.Event.StartsWith(CT_TRIGGER) ? "CT" : "T";

            string winType = null;
            if (evt.Event.StartsWith(CT_TRIGGER))
            {
                var winInformation = evt.Event.Substring(CT_TRIGGER.Length);
                winType = winInformation.Substring(0, winInformation.IndexOf("\""));
            }
            else
            {
                var winInformation = evt.Event.Substring(T_TRIGGER.Length);
                winType = winInformation.Substring(0, winInformation.IndexOf("\""));
            }

            if (OnRoundEnded != null)
                OnRoundEnded(new RoundWinEvent()
                {
                    EventTime = evt.DateTime,
                    OriginalEvent = evt.Event,
                    Team = team,
                    WinType = winType,
                });
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.StartsWith(CT_TRIGGER) || evt.Event.StartsWith(T_TRIGGER);
        }
    }
}
