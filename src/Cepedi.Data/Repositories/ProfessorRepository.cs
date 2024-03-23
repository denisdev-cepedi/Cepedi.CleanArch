using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly ApplicationDbContext _context;
    public ProfessorRepository(ApplicationDbContext context) => _context = context;

    public async Task<ProfessorEntity> ObtemProfessorPorIdAsync(int id)
    {
        return await _context.Professor.FirstOrDefaultAsync(professor => professor.Id == id) ?? throw new KeyNotFoundException();
    }
}
