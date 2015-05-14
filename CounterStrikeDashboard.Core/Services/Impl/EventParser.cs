using CounterStrikeDashboard.Core.Model;
using CounterStrikeDashboard.Core.Model.Events;
using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl
{
    public class EventParser : IEventParser
    {
        public CounterStrikeEvent ParseEvent(string evt)
        {
            var parsedEvent = ParseAction(evt);

            if (parsedEvent == null)
                return new NullEvent(evt);

            if (parsedEvent.Action == "killed")
            {
                return new KillEvent(evt)
                {
                    DateTime = parsedEvent.DateTime,
                    Killer = parsedEvent.Left,                    
                    Died = parsedEvent.Right,
                    Weapon = parsedEvent.ContextProperty
                };
            }

            return new NullEvent(evt);
        }

        private string CleanEvent(string evt)
        {
            const int OFFSET = 10;

            if (evt.Length <= OFFSET)
                return null;

            return evt.Substring(OFFSET).Trim();
        }

        private ParsedEvent ParseAction(string evt)
        {
            evt = CleanEvent(evt);

            if (evt == null)
                return null;

            const int DATETIME_LENGTH = 21;
            const int SPAM_LENGTH = 2;
            var datepart = evt.Substring(0, DATETIME_LENGTH);
            evt = evt.Substring(DATETIME_LENGTH + SPAM_LENGTH);

            var result = new ParsedEvent()
            {
                DateTime = DateTime.ParseExact(datepart, "MM/dd/yyyy - HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            };

            foreach (var kvp in _actions)
            {
                var action = kvp.Key;
                var info = kvp.Value;

                if (evt.Contains(action))
                {                   
                    var splitted = evt.Split(new string[] { action }, StringSplitOptions.RemoveEmptyEntries);
                    if (!info.IsContextEvent)
                    {
                        result.Left = TrimValue(splitted[0]);
                        result.Action = action.Trim();
                        result.Right = TrimValue(splitted[1]);
                    }
                    else
                    {
                        var ctxString = splitted[1];

                        for (int i = 0; i < _contextActions.Length; i++)
                        {
                            var ctxAction = _contextActions[i];
                            if (ctxString.Contains(ctxAction))
                            {
                                var ctxSplitted = ctxString.Split(new string[] { ctxAction }, StringSplitOptions.RemoveEmptyEntries);

                                result.Left = TrimValue(splitted[0]);
                                result.Action = action;
                                result.Right = TrimValue(ctxSplitted[0]);
                                result.ContextAction = ctxAction;
                                result.ContextProperty = TrimValue(ctxSplitted[1]);
                                break;
                            }
                        }
                    }

                    return result;
                }
            }

            return null;
        }

        private string TrimValue(string value)
        {
            int start;
            int end;

            for (start = 0; start < value.Length; start++)
            {
                if (value[start] == '\"')
                {
                    start++;
                    break;
                }
            }

            for (end = value.Length - 1; end >= 0; end-- )
            {
                if (value[end] == '\"')
                {
                    break;
                }
            }

            return value.Substring(start, end - start);
        }

        private Dictionary<string, EventInformation> _actions = new Dictionary<string,EventInformation>
        {
            { "killed", new EventInformation(true) }
        };

        private string[] _contextActions = new string[]
        {
            "with"
        };
    }
}
