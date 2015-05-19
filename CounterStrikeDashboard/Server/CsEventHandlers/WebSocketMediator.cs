using CounterStrikeDashboard.Core.CsEvents;
using CounterStrikeDashboard.Core.CsEvents.Events;
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
            _eventManager.DefusedBombEvent.OnPlayerDefusedBomb += DefusedBombEvent_OnPlayerDefusedBomb;
            _eventManager.StartedDefuseBombEvent.OnPlayerStartedDefusingBomb += StartedDefuseBombEvent_OnPlayerStartedDefusingBomb;

            _eventManager.ControlEvents.OnControlReset += ControlEvents_OnControlReset;
        }

        void StartedDefuseBombEvent_OnPlayerStartedDefusingBomb(StartedDefuseBombEvent obj)
        {
            HubContext.Clients.All.startedDefuseBomb(obj);
        }

        void DefusedBombEvent_OnPlayerDefusedBomb(DefusedBombEvent obj)
        {
            HubContext.Clients.All.defusedBomb(obj);
        }

        void KillEvent_OnPlayerKilled(KillEvent evt)
        {
            HubContext.Clients.All.playerKilled(evt);
        }

        void ControlEvents_OnControlReset()
        {
            HubContext.Clients.All.controlReset();
        }

        void RoundWinEvent_OnRoundEnded(RoundWinEvent evt)
        {
            HubContext.Clients.All.roundEnded(evt);
        }

        void MapStartedEvent_OnNewMapStarted(MapStartedEvent evt)
        {
            HubContext.Clients.All.newMapStarted(evt);
        }

        void JoinedTeamEvent_OnJoinedTeam(JoinedTeamEvent evt)
        {
            HubContext.Clients.All.joinedTeam(evt);
        }

        void JoinedTeamEvent_OnPlayerAdded(PlayerAddedEvent evt)
        {
            HubContext.Clients.All.playerAdded(evt);
        }
    }
}
