using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace CounterStrikeDashboard.Server.Persistence {
	public class CounterStrikeEvent {
		public ObjectId Id { get; set; }
    public string Description { get; set; }
	}
}
