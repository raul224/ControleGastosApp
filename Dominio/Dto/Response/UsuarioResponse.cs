namespace Dominio.Dto.Response;

public class UsuarioResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public double Saldo { get; set; }
}