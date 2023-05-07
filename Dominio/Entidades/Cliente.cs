using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClientId { get; set; }
        public double Saldo { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsaurioId { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
