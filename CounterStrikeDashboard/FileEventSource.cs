using CounterStrikeDashboard.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    public class FileEventSource : ICsEventSource
    {
        public event Action<string> OnNewEvent;

        public void Run(string fileName)
        {
            using (var file = File.OpenText(fileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (OnNewEvent != null)
                        OnNewEvent(line);
                }
            }
        }
    }
}
