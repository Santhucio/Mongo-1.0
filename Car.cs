using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBD1
{
    [BsonIgnoreExtraElements]
    public class Car
    {
        [BsonElement("manufacture")]
        public string Manufacture { get; set; }

        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        
        [BsonElement("color")]
        public string Color { get; set; }
        
        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("car_options")]
        public ICollection Car_options { get; set; }
    }
}
