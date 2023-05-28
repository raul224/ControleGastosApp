namespace Dominio.Dto.Response;

public class FlowResponse
{
    public string Id { get; set; }
    public DateTime DataLancamento { get; set; }
    public string DescricaoLancamento { get; set; }
    public double ValorLancamento { get; set; }
}