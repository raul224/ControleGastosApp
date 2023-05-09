using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ClientId { get; set; }
        public double Saldo { get; set; }
        public int UsuarioId { get; set; }
    }
}
