using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class WinEventHandler : IEventHandler
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

        public void Execute(Impl.EventParserHelpers.ParsedEvent evt, StateKeeper stateManager)
        {
            if (evt.Event.StartsWith(CT_TRIGGER))
            {
                stateManager.EndRound("CT");
            }
            else
            {
                stateManager.EndRound("T");
            }
        }

        public bool Matches(Impl.EventParserHelpers.ParsedEvent evt)
        {
            return evt.Event.StartsWith(CT_TRIGGER) || evt.Event.StartsWith(T_TRIGGER);
        }
    }
}
