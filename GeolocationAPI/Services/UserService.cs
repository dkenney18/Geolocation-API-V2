using System;
using System.Collections.Generic;
using GeolocationAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GeolocationAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> Get() =>
            _user.Find(user => true).ToList();

        public User Get(string id) =>
            _user.Find(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User UserIn) =>
            _user.ReplaceOne(User => User.Id == id, UserIn);

        public void Remove(string id) =>
            _user.DeleteOne(User => User.Id == id);
    }
}
