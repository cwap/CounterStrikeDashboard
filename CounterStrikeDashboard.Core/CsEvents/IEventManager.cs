using CounterStrikeDashboard.Core.CsEvents.ControlEvents;
using CounterStrikeDashboard.Core.CsEvents.CsHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents
{
    public interface IEventManager
    {
        void HandleEvent(string evt);
        void SendResetEvent();

        JoinedTeamEventHandler JoinedTeamEvent { get; }
        KillEventHandler KillEvent { get; }
        MapStartedEventHandler MapStartedEvent { get; }
        RoundWinEventHandler RoundWinEvent { get; }
        ControlEventsHandler ControlEvents { get; }
    }
}
