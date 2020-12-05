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

        //Get all To Do List items
        public IEnumerable<ToDoItem> GetAllItems()
        {
            var collection = _db.GetCollection<ToDoItem>("ToDoList");
            var items = collection.Find(new BsonDocument()).ToList();
            return items;
        }

        //Create new item
        public ToDoItem CreateItem(ToDoItem item)
        {
            try
            {
                var collection = _db.GetCollection<ToDoItem>("ToDoList");
                collection.InsertOne(item);
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Update item
        public ToDoItem UpdateItem(ToDoItem item)
        {
            var collection = _db.GetCollection<ToDoItem>("ToDoList");
            try
            {
                var filter = Builders<ToDoItem>.Filter.Eq("_id", item._id); //find document with existing username
                var update = Builders<ToDoItem>.Update.Set("name", item.name)
                    .Set("description", item.description)
                    .Set("date", item.date); //change firstname, lastname and password as such.
                collection.UpdateOne(filter, update);
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //Delete Item
        public string DeleteItem(ToDoItem item)
        {
            var collection = _db.GetCollection<ToDoItem>("ToDoList");
            try
            {
                var filter = Builders<ToDoItem>.Filter.Eq("_id", item._id);
                collection.DeleteOne(filter);
                return "Deleted!";
            }
            catch (Exception e)
            {
                return null;
            }
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
