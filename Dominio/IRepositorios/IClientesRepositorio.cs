using Dominio.Entidades;

namespace Dominio.IRepositorios;

public interface IClientesRepositorio
{
    IEnumerable<Lancamento> GetLancamentos(int clientId);

    Cliente GetCliente(int clientId);
}