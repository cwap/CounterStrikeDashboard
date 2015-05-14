using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public class Session
    {
        public Session()
        {
            Maps = new List<Map>();
        }

        public List<Map> Maps { get; set; }
    }
}
