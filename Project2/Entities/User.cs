using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Project2.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        [BsonElement("id")]
        public int Id { get; set; }
        
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        
        [BsonElement("LastName")]
        public string LastName { get; set; }
  
        [BsonElement("Username")]
        public string Username { get; set; }
        
        [BsonElement("Password")]
        public string Password { get; set; }
        
        [BsonElement("Role")]
        public string Role { get; set; }

        [BsonElement("Token")]
        public string Token { get; set; }
    }
}
