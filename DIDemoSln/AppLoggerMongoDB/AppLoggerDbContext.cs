using AppLoggerLibraryCS;
using MongoDB.Driver;

namespace AppLoggerMongoDB
{
    public class AppLoggerDbContext
    {
        private readonly IMongoDatabase _database;

        public AppLoggerDbContext()//string connectionString, string databaseName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("AppLoggerDB");
        }

        // Collection for Users
        public IMongoCollection<AppDataInfo> appDataInformation => _database.GetCollection<AppDataInfo>("AppDataLog");

        public IMongoCollection<ErrorInfo> errorInformation => _database.GetCollection<ErrorInfo>("ErrorLog");
    }
}
