using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Server
{
    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return "Client/";
        }
    }
}
