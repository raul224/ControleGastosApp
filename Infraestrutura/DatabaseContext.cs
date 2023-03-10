using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ControleGastos");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Lancamento> Lancamentos { get; set; }
}