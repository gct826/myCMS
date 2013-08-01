using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using myCMS.Helpers;

namespace myCMS.Models
{
    [BsonIgnoreExtraElements]
    public class Translation : MongoEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("isdefault")]
        public bool IsDefault { get; set; }

    }
}