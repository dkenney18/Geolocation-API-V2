using System.Collections.Generic;
using GeolocationAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace GeolocationAPI.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Cards")]
        public List<Card> Cards { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
