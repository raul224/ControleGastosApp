using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int clientId { get; set; }
        public double saldo { get; set; }
        public List<Lancamento> lancamentos { get; set; }
    }
}
