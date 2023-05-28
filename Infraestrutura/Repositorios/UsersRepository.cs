using Dominio.Entidades;
using Dominio.IRepositorios;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Infraestrutura.Repositorios;

public class UsersRepository : IUserRepositorio
{
    private readonly IMongoCollection<Users> usersCollection;
    
    public UsersRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);

        usersCollection = mongoDatabase.GetCollection<Users>("Users");
    }
    
    public async Task<Users> GetUserAsync(string email, string password)
    {
        return await usersCollection.FindSync(x => 
            x.Email.Equals(email.ToLower()) && 
            x.Password.Equals(password.ToLower())).FirstOrDefaultAsync();
    }

    public async Task AddUserAsync(Users users)
    {
        await usersCollection.InsertOneAsync(users);
    }
}