using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Exceptions
{
    public class CounterStrikeDashboardException : Exception
    {
        public CounterStrikeDashboardException() : base() { }
        public CounterStrikeDashboardException(string message) : base(message) { }
        public CounterStrikeDashboardException(string message, Exception innerException) : base(message, innerException) { }
    }
}
