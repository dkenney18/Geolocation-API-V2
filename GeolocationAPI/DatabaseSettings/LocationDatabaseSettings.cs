using System;
namespace GeolocationAPI.Models
{
    public class LocationDatabaseSettings : ILocationDatabaseSettings
    {
        public string LocationCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILocationDatabaseSettings
    {
        string LocationCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
