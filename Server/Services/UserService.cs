using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using Fullstack.Shared;
namespace Fullstack.Server.Services
{
    public class UserService{
        private IMongoCollection<User> _users;
        public UserService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoCloud"));
            var database = client.GetDatabase("MyDatabase");
            _users = database.GetCollection<User>("MyCollection");
        }
        public List<User> GetUsers() => _users.Find(user =>true).ToList();
        public User GetUser(string id) => _users.Find(user => user.Id == id).FirstOrDefault();
        public User PostUser(User user) {
            _users.InsertOne(user);
            return user;
        }
        public User PutUser(string id,User newUser){
            _users.ReplaceOne(user => user.Id == id , newUser);
            return newUser;
        }
        public User DeleteUser(string id){
            var oldUser = _users.Find(user => user.Id==id).FirstOrDefault();
            _users.DeleteOne(user => user.Id == id);
            return oldUser;
        }
    }
}
