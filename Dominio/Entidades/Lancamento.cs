using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Lancamentos")]
    public class Lancamento
    {
        [Key]
        public int id { get; set; }
        public DateTime DataLancamento { get; set; }
        public string DescricaoLancamento { get; set; }
        public double Valor { get; set; }
        [ForeignKey("clientId")]
        public int ClientId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
