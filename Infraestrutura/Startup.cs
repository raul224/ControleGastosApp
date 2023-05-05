using Dominio.IRepositorios;
using Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>();
        
        services.AddScoped<IClientesRepositorio, ClientesRepositorio>();
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
    }
}