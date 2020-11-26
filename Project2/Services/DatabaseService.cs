using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using Project2.Entities;
using Microsoft.AspNetCore.Mvc;

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


        public string DeleteUser(string username)
        {
            var collection = _db.GetCollection<User>("User");
            try
            {
                var filter = Builders<User>.Filter.Eq("Username", username);

                collection.DeleteOne(filter);
                return "Deleted!";
            }
            catch(Exception e)
            {
                return null;
            }

            
        }

        public NewUser Update(string username, NewUser newUser)
        {
            var collection = _db.GetCollection<User>("User");
            try
            {
                var filter = Builders<User>.Filter.Eq("Username", username); //find document with existing username
                var update = Builders<User>.Update.Set("FirstName", newUser.FirstName)
                    .Set("LastName", newUser.LastName)
                    .Set("Password", newUser.Password); //change firstname, lastname and password as such.
                collection.UpdateOne(filter, update);
                return newUser;
            }
            catch(Exception e)
            {
                return null;
            }
            


        }


        public User GetUserById(string username)
        {
            var collection = _db.GetCollection<User>("User");
            try
            {
                var filter = Builders<User>.Filter.Eq("Username", username);

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
