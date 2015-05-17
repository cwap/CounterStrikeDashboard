using CounterStrikeDashboard.Core.CsEvents;
using CounterStrikeDashboard.Server.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server.CsEventHandlers
{
    public class WebSocketMediator
    {
        private IEventManager _eventManager;
        private IHubContext _hubContext = null;
        private IHubContext HubContext
        {
            get
            {
                if (_hubContext == null)
                    _hubContext = GlobalHost.ConnectionManager.GetHubContext<EventHub>();

                return _hubContext;
            }
        }

        public WebSocketMediator(IEventManager eventManager)
        {
            _eventManager = eventManager;

            _eventManager.JoinedTeamEvent.OnJoinedTeam += JoinedTeamEvent_OnJoinedTeam;
            _eventManager.JoinedTeamEvent.OnPlayerAdded += JoinedTeamEvent_OnPlayerAdded;
            _eventManager.KillEvent.OnPlayerKilled += KillEvent_OnPlayerKilled;
            _eventManager.MapStartedEvent.OnNewMapStarted += MapStartedEvent_OnNewMapStarted;
            _eventManager.RoundWinEvent.OnRoundEnded += RoundWinEvent_OnRoundEnded;

            _eventManager.ControlEvents.OnControlReset += ControlEvents_OnControlReset;
        }

        void ControlEvents_OnControlReset()
        {
            HubContext.Clients.All.controlReset();
        }

        void RoundWinEvent_OnRoundEnded(DateTime arg1, string arg2)
        {
            HubContext.Clients.All.roundEnded(arg1, arg2);
        }

        void MapStartedEvent_OnNewMapStarted(DateTime arg1, string arg2)
        {
            HubContext.Clients.All.newMapStarted(arg1, arg2);
        }

        void JoinedTeamEvent_OnJoinedTeam(DateTime arg1, string arg2, string arg3, string arg4)
        {
            HubContext.Clients.All.joinedTeam(arg1, arg2, arg3, arg4);
        }

        void JoinedTeamEvent_OnPlayerAdded(DateTime arg1, string arg2, string arg3)
        {
            HubContext.Clients.All.playerAdded(arg1, arg2, arg3);
        }

        void KillEvent_OnPlayerKilled(DateTime arg1, string arg2, string arg3, string arg4, string arg5)
        {
            HubContext.Clients.All.playerKilled(arg1, arg2, arg3, arg4, arg5);
        }
    }
}
