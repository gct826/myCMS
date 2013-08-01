using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myCMS.Helpers
{
    public class MongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }

}