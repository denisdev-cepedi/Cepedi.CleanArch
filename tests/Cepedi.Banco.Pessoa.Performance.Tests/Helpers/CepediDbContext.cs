using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Banco.Pessoa.Benchmark.Test.Helpers;
public class CepediDbContext : DbContext
{
    private readonly string _connectionString;

    public CepediDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<UsuarioEntity> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
