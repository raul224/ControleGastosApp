using Dominio.Entidades;

namespace Dominio.Services;

public interface IClientesService
{
    List<Lancamento> GetLancamentos(int id);
    Task CadastraLancamento(Lancamento lancamento);
    Cliente GetCliente(int clientId);
}