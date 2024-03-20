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

    public async Task<CursoEntity> Create(CursoEntity curso, CancellationToken cancellationToken)
    {
        var entity = _context.Curso.Add(curso);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Entity;
    }

    public async Task<CursoEntity> Update(CursoEntity curso, CancellationToken cancellationToken)
    {
        var entity = _context.Curso.Update(curso);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Entity;
    }

    public async Task<int> Delete(int id, CancellationToken cancellationToken)
    {
        var curso = await GetById(id, cancellationToken);
        _context.Curso.Remove(curso);
        return await _context.SaveChangesAsync(cancellationToken);
    }
}