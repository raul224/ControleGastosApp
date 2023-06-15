using Dominio.Enums;

namespace Dominio.Dto;

public class FlowRegisterModel
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public double Value { get; set; }
    public string UserId { get; set; }
    public FlowType flowType{ get; set; }
}