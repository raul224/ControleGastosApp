namespace Dominio.Dto;

public class RegisterModel
{
    public string email { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string passwordValidate { get; set; }
}