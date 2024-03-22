using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

public class ProfessorRepository : IProfessorRepository
{
    private readonly ApplicationDbContext _context;

    public ProfessorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId) 
    => await _context.Professor.Where(professor => professor.Id == professorId).FirstOrDefaultAsync();
}