using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Dominio.Entidades
{
    public class Flow
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string UserId { get; set; }
        public string FlowType { get; set; }
    }
}
