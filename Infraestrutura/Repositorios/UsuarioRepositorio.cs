using Dominio.Entidades;
using Dominio.IRepositorios;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Infraestrutura.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly IMongoCollection<Usuario> usuarioCollection; 
    
    public UsuarioRepositorio(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);

        usuarioCollection = mongoDatabase.GetCollection<Usuario>("Usuarios");
    }
    
    public async Task<Usuario> GetUsuarioAsync(string email, string password)
    {
        return await usuarioCollection.FindSync(x => 
            x.Email.Equals(email.ToLower()) && 
            x.Password.Equals(password.ToLower())).FirstOrDefaultAsync();
    }

    public async Task CadastraUsuarioAsync(Usuario usuario)
    {
        await usuarioCollection.InsertOneAsync(usuario);
    }
}