using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    [ForeignKey("clientId")]
    public int clientId { get; set; }
}