using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public class TeamTuple : ModelBase
    {
        public string Team { get; set; }
        public int Score { get; set; }
    }
}