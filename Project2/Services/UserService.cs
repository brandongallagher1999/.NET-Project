using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project2.Entities;
using Project2.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;


namespace Project2.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(string username);
        User Create(User user);

        NewUser Update(string username, NewUser user);
        string DeleteUser(string username);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private DatabaseService db;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            db = new DatabaseService();
            
        }

        public User Authenticate(string username, string password)
        {
            var user = db.GetAll().SingleOrDefault(x => x.Username == username && x.Password == password);
            

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public NewUser Update(string username, NewUser user)
        {
            return db.Update(username, user);
        }

        public User Create(User user)
        {
            var response = db.CreateUser(user);
            response.Password = null; // dont want to see that cheeky password lol
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return db.GetAll().Select(x => {
                x.Password = null;
                return x;
            });
        }

        public string DeleteUser(string username)
        {
            return db.DeleteUser(username);
        }

        public User GetById(string username)
        {
            var user = db.GetUserById(username); //get user from db

            // return user without password
            if (user != null)
                user.Password = null;

            return user;
        }
    }
}
