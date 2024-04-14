using Cepedi.Dominio;
using Cepedi.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Dados;

public class ProfessorRepository : IProfessorRepository
{
    private readonly ApplicationDbContext _context;

    public ProfessorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ProfessorEntity> IncluirProfessorAsync(ProfessorEntity professor)
    {
        _context.Professor.Add(professor);
         _context.SaveChangesAsync();
         return Task.FromResult(professor);
    }

    public async Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId) 
    => await _context.Professor.Where(professor => professor.Id == professorId).FirstOrDefaultAsync();
}
