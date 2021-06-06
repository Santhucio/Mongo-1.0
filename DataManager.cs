using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBD1
{
    public class DataManager
    {
        private IMongoDatabase _database;
        public DataManager(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            _database =  mongoClient.GetDatabase(databaseName);
        }
        
        public IEnumerable<Car> GetCarsByNameTyped(string name)
        {
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Manufacture.Equals(name));
            return manufacture.ToEnumerable();
        }
        
        public IEnumerable<Car> GetCarsByYearTyped(int year)
        {
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Year >= year);
            return manufacture.ToEnumerable();
        }
        
        public IEnumerable<Car> GetCarsByOptionsTyped(string id) 
        {
            var collection = _database.GetCollection<Car>("users");
            var manufacture = collection.Find(x => x.Id.Equals(MongoDB.Bson.ObjectId.Parse(id)));
            return manufacture.ToEnumerable();
        }
    }
}
