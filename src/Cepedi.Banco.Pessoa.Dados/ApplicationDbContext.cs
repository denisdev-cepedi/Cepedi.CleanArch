using System.Diagnostics.CodeAnalysis;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Pessoa.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<UsuarioEntity> Usuario { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
