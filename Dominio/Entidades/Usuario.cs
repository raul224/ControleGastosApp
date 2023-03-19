using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Usario")]
public class Usuario
{
    [Key]
    public int id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    [ForeignKey("clientId")]
    public int clientId { get; set; }
}