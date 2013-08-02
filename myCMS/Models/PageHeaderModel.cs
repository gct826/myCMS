using MongoDB.Bson.Serialization.Attributes;
using myCMS.Helpers;

namespace myCMS.Models
{
    [BsonIgnoreExtraElements]
    public class PageHeader : MongoEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("permalink")]
        public string Permalink { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }
    }
}