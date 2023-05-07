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
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Lancamentos)
            .WithOne(l => l.Cliente)
            .HasForeignKey(l => l.ClientId);

        modelBuilder.Entity<Usuario>()
            .HasOne<Cliente>(u => u.Cliente)
            .WithOne(c => c.Usuario)
            .HasForeignKey<Cliente>(c => c.ClientId);

        modelBuilder.Entity<Lancamento>()
            .HasOne<Cliente>(l => l.Cliente)
            .WithMany(c => c.Lancamentos)
            .HasForeignKey(l => l.ClientId);
    }
}