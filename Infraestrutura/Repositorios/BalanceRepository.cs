using Dominio.Entidades;
using Dominio.IRepositorios;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infraestrutura.Repositorios;

public class BalanceRepository : IBalanceRepository
{
    
    private readonly IMongoCollection<Flow> flowCollection;
    
    public BalanceRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);
        
        flowCollection = mongoDatabase.GetCollection<Flow>("Flows");
    }
    
    public async Task<IEnumerable<Flow>> GetFlowsAsync(string clientId)
    {
        var cursor =  await flowCollection
            .FindAsync(x => x.UserId.Equals(clientId) && 
                            x.Date < DateTime.Now.AddDays(90));
        return await cursor.ToListAsync();
    }

    public async Task<IEnumerable<Flow>> GetFlowsPreviewAsync(
        DateTime initialDate, 
        DateTime finalDate, 
        string usuarioId)
    {
        var cursor = await flowCollection.FindAsync(
            x => x.Date >= initialDate && 
                 x.Date <= finalDate && x.UserId.Equals(usuarioId));
        return await cursor.ToListAsync();
    }

    public async Task AddFlowAsync(Flow flow)
    {
        await flowCollection.InsertOneAsync(flow);
    }
}