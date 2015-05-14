using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public class Map
    {
        public Map()
        {
            Players = new List<PlayerTuple>();
            Teams = new List<TeamTuple>()
            {
                new TeamTuple() { Team = "CT" },
                new TeamTuple() { Team = "T" },
            };
        }

        public DateTime Start { get; set; }
        public string MapName { get; set; }
        public List<PlayerTuple> Players { get; set; }
        public List<TeamTuple> Teams { get; set; }
        public bool Active { get; set; }
    }
}
