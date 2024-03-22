using Cepedi.Domain.Repository;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> AtualizaCursoAsync(CursoEntity curso)
    {
        _context.Curso.Update(curso);
        return _context.SaveChangesAsync();
    }
    public Task<int> ExcluiCursoAsync(int idCurso)
    {
        _context.Curso.Remove(_context.Curso.Find(idCurso));
        return _context.SaveChangesAsync();
    }
    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) =>
        await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    public async Task<List<CursoEntity>> ObtemCursosAsync()
    {
        return await _context.Curso.ToListAsync();
    }

    Task<int> ICursoRepository.CadastraNovoCursoAsync(CursoEntity curso)
    {
        _context.Curso.Add(curso);
        return _context.SaveChangesAsync();
    }
}
