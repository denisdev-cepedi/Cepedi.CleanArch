using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly ApplicationDbContext _context;
    public ProfessorRepository(ApplicationDbContext context) => _context = context;

    public async Task<ProfessorEntity> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Professor
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Professor with id {id} not found.");
    }

    public async Task<IEnumerable<ProfessorEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Professor
            .ToListAsync(cancellationToken);
    }

}
