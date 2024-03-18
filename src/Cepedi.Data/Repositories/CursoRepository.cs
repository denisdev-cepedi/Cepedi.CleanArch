using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : BaseRepository<CursoEntity>, ICursoRepository
{
    public CursoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<CursoEntity> GetById(int id, CancellationToken cancellationToken)
    {
        return await _context.Curso
            .Include(c => c.Professor)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new KeyNotFoundException($"Curso with id {id} not found.");
    }
}