using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Lancamentos")]
    public class Lancamento
    {
        [Key]
        public int id { get; set; }
        public DateTime dataLancamento { get; set; }
        public string descricaoLancamento { get; set; }
        public double valor { get; set; }
        [ForeignKey("clientId")]
        public int clientId { get; set; }
    }
}
