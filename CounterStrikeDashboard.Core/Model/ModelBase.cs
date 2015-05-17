using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Model
{
    public abstract class ModelBase
    {
        [JsonProperty(PropertyName = "__name__")]
        public string ClassName
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
