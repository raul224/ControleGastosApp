using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades
{
    public class Lancamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public DateTime DataLancamento { get; set; }
        public string DescricaoLancamento { get; set; }
        public string ClientId { get; set; }
    }
}
