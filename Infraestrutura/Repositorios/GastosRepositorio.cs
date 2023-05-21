using Dominio.Entidades;
using Dominio.IRepositorios;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infraestrutura.Repositorios;

public class GastosRepositorio : IGastosRepositorio
{
    
    private readonly IMongoCollection<Lancamento> lancamentoCollection;
    
    public GastosRepositorio(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);
        
        lancamentoCollection = mongoDatabase.GetCollection<Lancamento>("Lancamentos");
    }
    
    public async Task<IEnumerable<Lancamento>> GetLancamentosAsync(string clientId)
    {
        var cursor =  await lancamentoCollection
            .FindAsync(x => x.UsuarioId.Equals(clientId) && 
                            x.DataLancamento < DateTime.Now.AddDays(90));
        return await cursor.ToListAsync();
    }

    public async Task<IEnumerable<Lancamento>> GetLancamentosComFiltroAsync(
        DateTime dataIncio, 
        DateTime dataFim, 
        string usuarioId)
    {
        var cursor = await lancamentoCollection.FindAsync(
            x => x.DataLancamento >= dataIncio && 
                 x.DataLancamento <= dataFim && x.UsuarioId.Equals(usuarioId));
        return await cursor.ToListAsync();
    }

    public async Task cadastraLancamentoAsync(Lancamento lancamento)
    {
        await lancamentoCollection.InsertOneAsync(lancamento);
    }
}