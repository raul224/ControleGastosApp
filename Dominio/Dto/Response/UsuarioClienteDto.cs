using Dominio.Entidades;

namespace Dominio.Dto;

public class UsuarioClienteDto
{
    public Usuario Usuario { get; set; }
    public Cliente Cliente { get; set; }
}