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
        return _context
        .Lancamentos
        .Where(x => x.ClientId == clientId && 
                    x.DataLancamento < DateTime.Now.AddDays(90));
    }

    public IEnumerable<Lancamento> GetLancamentosComFiltro(DateTime dataIncio, DateTime dataFim)
    {
        return _context
            .Lancamentos
            .Where(x => x.DataLancamento >= dataIncio && 
                        x.DataLancamento <= dataFim);
    }

    public async Task cadastraLancamento(Lancamento lancamento)
    {
        _context.Lancamentos.Add(lancamento);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente> GetCliente(int clientId)
    {
        var cliente = await _context.Clientes.FindAsync(clientId);
        return cliente ?? new Cliente();
    }

    public async Task CadastraCliente(Usuario usuario)
    {
        var cliente = new Cliente
        {
            Saldo = 0,
            Usuario = usuario,
            UsaurioId = usuario.Id
        };
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }
}