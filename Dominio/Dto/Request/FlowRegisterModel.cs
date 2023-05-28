namespace Dominio.Dto;

public class FlowRegisterModel
{
    public DateTime DataLancamento { get; set; }
    public string DescricaoLancamento { get; set; }
    public double ValorLancamento { get; set; }
    public string UsuarioId { get; set; }
}