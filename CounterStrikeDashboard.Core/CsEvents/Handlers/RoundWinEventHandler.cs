using CounterStrikeDashboard.Core.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.Handlers
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

        public event Action<DateTime, string> OnRoundEnded;

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt)
        {
            var team = evt.Event.StartsWith(CT_TRIGGER) ? "CT" : "T";

            if (OnRoundEnded != null)
                OnRoundEnded(evt.DateTime, team);
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.StartsWith(CT_TRIGGER) || evt.Event.StartsWith(T_TRIGGER);
        }
    }
}
