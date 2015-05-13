using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Infrastructure
{
    public class CounterStrikeCommunicatorConfiguration
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string RConPassword { get; set; }
    }
}
