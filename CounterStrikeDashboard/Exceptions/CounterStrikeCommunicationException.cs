using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Exceptions
{
    public class CounterStrikeCommunicationException : CounterStrikeDashboardException
    {
        public CounterStrikeCommunicationException() : base() { }
        public CounterStrikeCommunicationException(string message) : base(message) { }
        public CounterStrikeCommunicationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
