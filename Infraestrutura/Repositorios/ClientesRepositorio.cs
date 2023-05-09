using Dominio.Entidades;
using Dominio.IRepositorios;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infraestrutura.Repositorios;

public class ClientesRepositorio : IClientesRepositorio
{
    private readonly IMongoCollection<Cliente> clienteCollection;
    private readonly IMongoCollection<Lancamento> lancamentoCollection;

    public ClientesRepositorio(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);

        clienteCollection = mongoDatabase.GetCollection<Cliente>("Clientes");
        lancamentoCollection = mongoDatabase.GetCollection<Lancamento>("Lancamentos");
    }
    
    public async Task<IEnumerable<Lancamento>> GetLancamentosAsync(int clientId)
    {
        var cursor =  await lancamentoCollection
        .FindAsync(x => x.ClientId == clientId && 
                    x.DataLancamento < DateTime.Now.AddDays(90));
        return await cursor.ToListAsync();
    }

    public async Task<IEnumerable<Lancamento>> GetLancamentosComFiltroAsync(DateTime dataIncio, DateTime dataFim)
    {
        var cursor = await lancamentoCollection.FindAsync(
            x => x.DataLancamento >= dataIncio && 
                 x.DataLancamento <= dataFim);
        return await cursor.ToListAsync();
    }

    public async Task cadastraLancamentoAsync(Lancamento lancamento)
    {
        await lancamentoCollection.InsertOneAsync(lancamento);
    }

    public async Task<Cliente> GetClienteAsync(int clientId)
    {
        var cliente = 
            await clienteCollection.FindAsync(x => x.ClientId == clientId);
        return await cliente.FirstOrDefaultAsync();
    }

    public async Task CadastraClienteAsync(Usuario usuario)
    {
        var cliente = new Cliente
        {
            Saldo = 0,
            UsuarioId= usuario.Id
        };
        await clienteCollection.InsertOneAsync(cliente);
    }

    public async Task<Cliente> GetClientByUser(int userId)
    {
        var cursor = await clienteCollection.FindAsync(x => x.UsuarioId == userId);
        return await cursor.FirstOrDefaultAsync();
    }
}