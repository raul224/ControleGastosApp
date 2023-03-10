namespace Dominio.Entidades
{
    public class Lancamento
    {
        public DateTime dataLancamento { get; set; }
        public string descricaoLancamento { get; set; }
        public double valor { get; set; }
        public int clientId { get; set; }
    }
}
