using Dominio.Entidades;
using Dominio.IRepositorios;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infraestrutura.Repositorios;

public class ClientesRepositorio : IClientesRepositorio
{
    private readonly IMongoCollection<Cliente> clienteCollection;

    public ClientesRepositorio(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);

        clienteCollection = mongoDatabase.GetCollection<Cliente>("Clientes");
        
    }

    public async Task<Cliente> GetClienteAsync(string clientId)
    {
        var cliente = 
            await clienteCollection.FindAsync(x => x.Id.Equals(clientId));
        return await cliente.FirstOrDefaultAsync();
    }

    public async Task CadastraClienteAsync(Cliente cliente)
    {
        await clienteCollection.InsertOneAsync(cliente);
    }

    public async Task<Cliente> GetClientByUser(string userId)
    {
        var cursor = await clienteCollection.FindAsync(x => x.UsuarioId.Equals(userId));
        return await cursor.FirstOrDefaultAsync();
    }
}