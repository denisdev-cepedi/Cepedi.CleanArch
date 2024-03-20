using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;
    public CursoRepository(ApplicationDbContext context) => _context = context;

    public async Task<CursoEntity> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Curso
            .Include(c => c.Professor)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Curso with id {id} not found.");
    }

    public async Task<IEnumerable<CursoEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Curso
            .Include(c => c.Professor)
            .ToListAsync(cancellationToken);
    }
}