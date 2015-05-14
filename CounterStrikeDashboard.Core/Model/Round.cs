using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public class Round
    {
        public Round()
        {
            Scores = new List<ScoreTuple>();
        }

        public DateTime Start { get; set; }
        public string Map { get; set; }
        public List<ScoreTuple> Scores { get; set; }
        public bool Active { get; set; }
    }
}
