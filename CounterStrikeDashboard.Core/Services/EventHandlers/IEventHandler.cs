using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    interface IEventHandler
    {
        void Execute(ParsedEvent evt, StateKeeper stateManager);
        bool Matches(ParsedEvent evt);
    }
}
