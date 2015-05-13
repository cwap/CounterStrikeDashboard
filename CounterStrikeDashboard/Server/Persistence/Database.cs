using MongoDB.Driver;

namespace CounterStrikeDashboard.Server.Persistence {
	public class Database
	{
		private IMongoDatabase _database;
		public IMongoCollection<CounterStrikeEvent> LogItems { get; private set; }

		private static Database instance;

		public static Database GetInstance()
		{
			if (instance == null)
			{
				instance = new Database();
			}
			return instance;
		}

		private Database()
		{
			var client = new MongoClient();
			_database = client.GetDatabase("db");
			LogItems = _database.GetCollection<CounterStrikeEvent>("items");
		}

		public async void AddLogEntry(CounterStrikeEvent gameEvent)
		{
			await LogItems.InsertOneAsync(gameEvent);
		}
	}
}
