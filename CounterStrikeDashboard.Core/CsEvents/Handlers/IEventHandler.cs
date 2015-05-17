using CounterStrikeDashboard.Core.Api;
using CounterStrikeDashboard.Core.CsEvents.Impl.EventParserHelpers;
using System;
namespace CounterStrikeDashboard.Core.CsEvents.Handlers
{
    public interface ICsEventHandler
    {
        void Execute(ParsedEvent evt);
        bool Matches(ParsedEvent evt);
    }
}
