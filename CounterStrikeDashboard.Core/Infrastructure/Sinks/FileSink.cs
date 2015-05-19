using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Infrastructure.Sinks
{
    public class FileSink : ICsEventSink, IDisposable
    {
        StreamWriter writer;

        public FileSink(string filename = null)
        {
            if (String.IsNullOrEmpty(filename))
                filename = DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".txt";

            writer = new StreamWriter(filename);
            
        }

        public void HandleEvent(string csEvent)
        {
            writer.WriteLine(csEvent);
        }

        public void Dispose()
        {
            writer.Dispose();
        }


        public void ReplayEvent(string csEvent)
        {
            //do nothing
        }
    }
}
