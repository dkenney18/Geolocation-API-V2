using System.Collections.Generic;
using GeolocationAPI.Models;
using MongoDB.Driver;

namespace GeolocationAPI.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _location;

        public LocationService(ILocationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _location = database.GetCollection<Location>(settings.LocationCollectionName);
        }

        public List<Location> Get(string userID, string cardNumber) =>
            _location.Find(location => location.UserID == userID && location.CardNumber == cardNumber).ToList();

        public Location Create(Location location)
        {
            _location.InsertOne(location);
            return location;
        }

        public void Remove(string userID, string cardNumber) =>
            _location.DeleteOne(location => location.UserID == userID && location.CardNumber == cardNumber);
    }
}
