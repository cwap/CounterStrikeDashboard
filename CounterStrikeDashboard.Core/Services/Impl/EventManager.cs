using CounterStrikeDashboard.Core.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl
{
    public class EventManager : IEventManager
    {
        private IEventParser _eventParser;
        
        public EventManager(IEventParser eventParser = null)
        {
            this._eventParser = eventParser ?? new EventParser();
        }

        public void HandleEvent(string evt)
        {
            var csEvent = _eventParser.ParseEvent(evt);

            if (csEvent is KillEvent)
            {
                var killEvent = (KillEvent)csEvent;
                Console.WriteLine("{0}: {1} killed {2} using {3}", killEvent.DateTime, killEvent.Killer, killEvent.Died, killEvent.Weapon);
            }
        }
    }
}
