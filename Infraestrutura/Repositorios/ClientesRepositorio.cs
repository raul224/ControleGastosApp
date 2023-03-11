using Dominio.Entidades;
using Dominio.IRepositorios;

namespace Infraestrutura.Repositorios;

public class ClientesRepositorio : IClientesRepositorio
{
    private DatabaseContext _context;

    public ClientesRepositorio(DatabaseContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Lancamento> GetLancamentos(int clientId)
    {
        return _context.Lancamentos.Where(x => x.clientId == clientId);
    }

    public Cliente GetCliente(int clientId)
    {
        var cliente = _context.Clientes.Find(clientId);
        return cliente ?? new Cliente();
    }
}