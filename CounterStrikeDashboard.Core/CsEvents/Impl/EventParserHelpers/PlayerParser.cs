using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.CsEvents.EventParserHelpers
{
    static class PlayerParser
    {
        public static void ParsePlayer(string playerString, out string player, out string uid, out string team)
        {
            // Template "[P*D]Chris_Rock (100)<3><BOT><TERRORIST>"
            var playerRegex = new Regex("\".*?<");
            var almostPlayerName = playerRegex.Match(playerString).Value;
            player = almostPlayerName.Substring(1, almostPlayerName.Length - 2);

            var infoRegex = new Regex("<.*?>");
            var almostPlayerUid = infoRegex.Matches(playerString)[1].Value;
            uid = almostPlayerUid.Substring(1, almostPlayerUid.Length - 2);

            var almostTeam = infoRegex.Matches(playerString)[2].Value;
            var teamStr = almostTeam.Substring(1, almostTeam.Length - 2);
            if (string.IsNullOrEmpty(teamStr))
                team = "NONE";
            else if (teamStr == "CT")
                team = "CT";
            else
                team = "T";

            // Fix for bots
            if (uid == "BOT")
                uid = player;
        }
    }
}
