using CounterStrikeDashboard.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    public class FileEventSource : IEventSource
    {
        public event Action<string> OnNewEvent;

        public void Run()
        {
            using (var file = File.OpenText("lol3.txt"))
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
