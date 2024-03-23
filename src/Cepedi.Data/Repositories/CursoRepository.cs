using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;
    public CursoRepository(ApplicationDbContext context) => _context = context;

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int id)
    {
        return await _context.Curso.FirstOrDefaultAsync(curso => curso.Id == id) ?? throw new KeyNotFoundException();
    }

    public async Task<IEnumerable<CursoEntity>> ObtemCursosAsync()
    {
        return await _context.Curso.ToListAsync();
    }

    public async Task<int> CriaNovoCursoAsync(CursoEntity curso)
    {
        await _context.Curso.AddAsync(curso);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> AtualizaCursoAsync(CursoEntity curso)
    {
        _context.Curso.Update(curso);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeletaCursoAsync(int id)
    {
        var curso = await ObtemCursoPorIdAsync(id);
        _context.Curso.Remove(curso);
        return await _context.SaveChangesAsync();
    }
}