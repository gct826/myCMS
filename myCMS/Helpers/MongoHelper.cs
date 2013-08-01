using System.Configuration;
using MongoDB.Driver;

namespace myCMS.Helpers
{
    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }

        public MongoHelper()
        {
            
            
            var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["PersonalMongoDB"].ConnectionString);


            var mongoClient = new MongoClient(con.ConnectionString);
            var mongoServer = mongoClient.GetServer();
            var db = mongoServer.GetDatabase(con.DatabaseName);

            Collection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}