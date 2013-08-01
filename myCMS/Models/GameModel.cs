using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using myCMS.Helpers;

namespace myCMS.Models
{
    [BsonIgnoreExtraElements]
    public class Game : MongoEntity
    {
        //public Game()
        //{
        //    Categories = new List<string>();
        //}

        //[BsonId]
        //public ObjectId GameId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("release_date")]
        public DateTime ReleaseDate { get; set; }

        //[BsonElement("categories")]
        //public List<string> Categories { get; set; }
        
        [BsonElement("played")]
        public bool Played { get; set; }

    }
}