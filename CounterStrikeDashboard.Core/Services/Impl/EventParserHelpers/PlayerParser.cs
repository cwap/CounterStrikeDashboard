using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services.Impl.EventParserHelpers
{
    class PlayerParser
    {
        public static void ParsePlayer(string playerString, out string player, out string uid)
        {
            var playerRegex = new Regex("\".*?<");
            var almostPlayerName = playerRegex.Match(playerString).Value;
            player = almostPlayerName.Substring(1, almostPlayerName.Length - 2);

            var uidRegex = new Regex("<.*?>");
            var almostPlayerUid = uidRegex.Matches(playerString)[1].Value;
            uid = almostPlayerUid.Substring(1, almostPlayerUid.Length - 2);
        }
    }
}
