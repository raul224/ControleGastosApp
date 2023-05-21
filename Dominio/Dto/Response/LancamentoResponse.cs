namespace Dominio.Dto.Response;

public class LancamentoResponse
{
    public string Id { get; set; }
    public DateTime DataLancamento { get; set; }
    public string DescricaoLancamento { get; set; }
    public double ValorLancamento { get; set; }
}