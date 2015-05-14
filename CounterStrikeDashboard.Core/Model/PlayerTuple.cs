using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public class PlayerTuple
    {
        public string Name { get; set; }
        public string UniqueIdentifier { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }

        public bool Connected { get; set; }
    }
}
