using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    [ForeignKey("clientId")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}