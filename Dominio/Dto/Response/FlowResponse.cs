namespace Dominio.Dto.Response;

public class FlowResponse
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public double Value { get; set; }
    public string FlowType { get; set; }
}