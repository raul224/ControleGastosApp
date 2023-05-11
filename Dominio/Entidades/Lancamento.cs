using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Dominio.Entidades
{
    public class Lancamento
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public DateTime DataLancamento { get; set; }
        public string DescricaoLancamento { get; set; }
        public string UsuarioId { get; set; }
    }
}
