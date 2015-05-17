using CounterStrikeDashboard.Core.CsEvents.Handlers;
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

        JoinedTeamEventHandler JoinedTeamEvent { get; }
        KillEventHandler KillEvent { get; }
        MapStartedEventHandler MapStartedEvent { get; }
        RoundWinEventHandler RoundWinEvent { get; }
    }
}
