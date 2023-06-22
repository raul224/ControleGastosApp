using Dominio.Entidades;
using Dominio.IRepositorios;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Dominio.Enums;

namespace Infraestrutura.Repositorios;

public class UsersRepository : IUserRepository
{
    private readonly IMongoCollection<Users> _usersCollection;
    
    public UsersRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
            databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DataBaseName);

        _usersCollection = mongoDatabase.GetCollection<Users>("Users");
    }
    
    public async Task<Users> GetUserAsync(string email, string password)
    {
        return await _usersCollection.FindSync(x => 
            x.Email.Equals(email.ToLower()) && 
            x.Password.Equals(password.ToLower())).FirstOrDefaultAsync();
    }

    public async Task AddUserAsync(Users users)
    {
        await _usersCollection.InsertOneAsync(users);
    }

    public async Task UpdateUserAsync(FlowType flowType, string userId, double value)
    {
        var user = await _usersCollection
            .Find(x => x.Id.Equals(ObjectId.Parse(userId)))
            .FirstOrDefaultAsync();

        if (flowType == FlowType.Credit){
            user.Balance += value;
        }else {
            user.Balance -= value;
        }

        await _usersCollection.ReplaceOneAsync(x => x.Id.Equals(ObjectId.Parse(userId)), user);
    }

    public async Task<Users> GetUserByIdAsync(string userId)
    {
        return await _usersCollection
            .FindSync(x => 
                x.Id.Equals(ObjectId.Parse(userId)))
            .FirstOrDefaultAsync();
    }
}