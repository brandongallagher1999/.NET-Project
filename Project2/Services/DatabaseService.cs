using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Project2.Entities;

namespace Project2.Services
{
    public class DatabaseService
    {

        private MongoClient _client;
        private IMongoDatabase _db;

        public DatabaseService()
        {
            _client = new MongoClient(
                "mongodb+srv://cryptoguys:LXwbkgdz5G9QOr7p@cluster0.bk4fd.mongodb.net/<dbname>?retryWrites=true&w=majority"
            );

            _db = _client.GetDatabase("project");
        }

        public IEnumerable<User> GetAll()
        {
            var collection = _db.GetCollection<User>("User");
            var users = collection.Find(new BsonDocument()).ToList();
            return users;
        }

        public User CreateUser(User user)
        {
            try
            {
                var collection = _db.GetCollection<User>("User");
                collection.InsertOne(user);
                return user;
            }
            catch(Exception e)
            {
                return null;
            }
            

        }


        public User GetUserById(int id)
        {
            var collection = _db.GetCollection<User>("User");
            try
            {
                var filter = Builders<User>.Filter.Eq("id", id);

                User doc = collection.Find(filter).First();

                return doc;
            }
            catch(Exception e)
            {
                return null; //return null if user is not found.
            }
        }



    }
}
