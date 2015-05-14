using CounterStrikeDashboard.Core.Services.EventHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl
{
    public class EventManager : IEventManager
    {
        private IEventParser _eventParser;
        private StateKeeper _stateKeeper;

        public EventManager(StateKeeper stateKeeper, IEventParser eventParser = null)
        {
            this._eventParser = eventParser ?? new EventParser();
            this._stateKeeper = stateKeeper;
        }

        public void HandleEvent(string evt)
        {
            Console.WriteLine(evt);

            var csEvent = _eventParser.ParseEvent(evt);

            foreach (var eventHandler in _eventHandlers)
            {
                if (csEvent != null && eventHandler.Matches(csEvent))
                    eventHandler.Execute(csEvent, _stateKeeper);
            }
        }

        private readonly List<IEventHandler> _eventHandlers = new List<IEventHandler>()
        {
            //new DefusedBombEventHandler(),
            //new JoinedTeamEventHandler(),
            //new KillEventHandler(),
            new MapStartedEventHandler(),
            //new PlantedTheBombEventHandler(),
            //new RoundStartEventHandler(),
            //new StartedDefuseBombEventHandler(),
            new WinEventHandler(),

        };
    }
}
