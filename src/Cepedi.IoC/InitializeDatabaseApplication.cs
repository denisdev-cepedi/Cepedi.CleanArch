using Cepedi.Data;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cepedi.IoC;
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
        var professor = new ProfessorEntity(1, "João", "Matemática");
        var curso = new CursoEntity(1, "Matemática Básica", "Curso introdutório de matemática", DateTime.Now, DateTime.Now.AddMonths(3), professor);

        // Adicionando o curso à lista de cursos do professor
        professor.Cursos.Add(curso);

        // Default data
        // Seed, if necessary
        if (!_context.Professor.Any())
        {
            _context.Professor.Add(professor);
            //_context.TodoLists.Add(new TodoList
            //{
            //    Title = "Todo List",
            //    Items =
            //    {
            //        new TodoItem { Title = "Make a todo list 📃" },
            //        new TodoItem { Title = "Check off the first item ✅" },
            //        new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
            //        new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
            //    }
            //});

            await _context.SaveChangesAsync();
        }
    }
}
