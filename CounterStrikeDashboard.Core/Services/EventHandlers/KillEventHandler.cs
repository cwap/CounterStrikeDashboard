using CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.EventHandlers
{
    class KillEventHandler : IEventHandler
    {
        // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>" killed "[POD]Pissed Off (100)<7><BOT><CT>" with "ak47"

        public bool Matches(ParsedEvent evt)
        {
            return evt.Event.Contains("\" killed \"");
        }

        public void Execute(ParsedEvent evt, StateKeeper stateManager)
        {
            var splitted = evt.Event.Split(new string[] { " killed " }, StringSplitOptions.RemoveEmptyEntries);
            var killerString = splitted[0];            

            var rightSplitted = splitted[1].Split(new string[] { " with " }, StringSplitOptions.RemoveEmptyEntries);
            var deadManString = rightSplitted[0];

            string killerName;
            string killerUid;

            string deadManName;
            string deadManUid;

            ParsePlayer(killerString, out killerName, out killerUid);
            ParsePlayer(deadManString, out deadManName, out deadManUid);

            stateManager.ApplyKill(killerName, killerUid, deadManName, deadManUid);
        }

        private void ParsePlayer(string playerString, out string player, out string uid)
        {
            // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>"
            var playerRegex = new Regex("\".*?<");
            var almostPlayerName = playerRegex.Match(playerString).Value;
            player = almostPlayerName.Substring(1, almostPlayerName.Length - 2);

            var uidRegex = new Regex("<.*?>");
            var almostPlayerUid = uidRegex.Matches(playerString)[1].Value;
            uid = almostPlayerUid.Substring(1, almostPlayerUid.Length - 2);
        }
    }
}
