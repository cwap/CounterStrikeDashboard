using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents.ControlEvents;
using CounterStrikeDashboard.Core.CsEvents.CsHandlers;
using CounterStrikeDashboard.Core.Infrastructure;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.CsEvents.Impl
{
    public class EventManager : IEventManager
    {
        private static readonly Logger _log = LogManager.GetCurrentClassLogger();

        private IEventParser _eventParser;
        private List<ICsEventSink> _csEventSinks;

        private readonly List<ICsEventHandler> _eventHandlers;
        public JoinedTeamEventHandler JoinedTeamEvent { get; private set; }
        public KillEventHandler KillEvent { get; private set; }
        public MapStartedEventHandler MapStartedEvent { get; private set; }
        public RoundWinEventHandler RoundWinEvent { get; private set; }
        public ControlEventsHandler ControlEvents { get; private set; }

        public EventManager(IEventParser eventParser = null, IEnumerable<ICsEventSink> eventSinks = null)
        {
            this._eventParser = eventParser ?? new EventParser();

            _csEventSinks = new List<ICsEventSink>(eventSinks ?? new List<ICsEventSink>());

            JoinedTeamEvent = new JoinedTeamEventHandler();
            KillEvent = new KillEventHandler();
            MapStartedEvent = new MapStartedEventHandler();
            RoundWinEvent = new RoundWinEventHandler();
            ControlEvents = new ControlEventsHandler();

            _eventHandlers = new List<ICsEventHandler>()
            {
                JoinedTeamEvent,
                KillEvent,
                MapStartedEvent,
                RoundWinEvent
            };
        }

        public void SendResetEvent()
        {
            ControlEvents.FireResetEvent();
        }

        public void HandleEvent(string evt)
        {           
            try
            {
                var csEvent = _eventParser.ParseEvent(evt);

                foreach (var eventHandler in _eventHandlers)
                {
                    if (csEvent != null && eventHandler.Matches(csEvent))
                        eventHandler.Execute(csEvent);
                }
            }
            catch (Exception ex)
            {
                _log.Warn(String.Format("Ignoring event since we got error while parsing event: {0}", evt), ex);
            }

            foreach (var eventSink in _csEventSinks)
                eventSink.HandleEvent(evt);
        }        
    }
}
