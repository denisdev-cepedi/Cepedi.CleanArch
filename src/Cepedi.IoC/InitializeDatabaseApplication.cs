using Cepedi.BancoCentral.Data;
using Cepedi.BancoCentral.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.IoC;
public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var usuario = new UsuarioEntity { Nome = "Denis", Celular = "71992414041", CelularValidado = true, 
            Cpf = "1234567891", DataNascimento = DateTime.Now.AddYears(-31), Email = "denis.vieira@cepedi.org.br" };

        // Default data
        // Seed, if necessary
        if (!_context.Usuario.Any())
        {
            _context.Usuario.Add(usuario);

            await _context.SaveChangesAsync();
        }
    }
}
