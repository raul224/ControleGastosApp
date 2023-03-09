namespace Dominio.Entidades
{
    public class Cliente
    {
        public Guid clientId { get; set; }
        public double saldo { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
