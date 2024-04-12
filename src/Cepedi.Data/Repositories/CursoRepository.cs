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

    public async Task<CursoEntity> CriaNovoCursoAsync(CursoEntity curso)
    {
        await _context.Curso.AddAsync(curso);
        await _context.SaveChangesAsync();
        return curso;

    }

    public async Task<CursoEntity> AtualizaCursoAsync(CursoEntity curso)
    {
        _context.Curso.Update(curso);
        await _context.SaveChangesAsync();
        return curso;
    }

    public async Task<CursoEntity> DeletaCursoAsync(int id)
    {
        var curso = await ObtemCursoPorIdAsync(id);
        _context.Curso.Remove(curso);
        await _context.SaveChangesAsync();
        return curso;
    }
}