using System.Diagnostics.CodeAnalysis;
using Cepedi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Dados;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<ProfessorEntity> Professor { get; set; } = default!;
    public DbSet<CursoEntity> Curso { get; set; } = default!;

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
