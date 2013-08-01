using MongoDB.Bson;

namespace myCMS.Helpers
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}