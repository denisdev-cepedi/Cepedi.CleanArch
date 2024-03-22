using Cepedi.Domain;
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

    public Task<int> AlterarCursoAsync(CursoEntity curso)
    {
        _context.Curso.Update(curso);
        return _context.SaveChangesAsync();
    }

    public Task<CursoEntity> CriarCursoAsync(CursoEntity curso)
    {
        _context.Curso.Add(curso);
        _context.SaveChanges();
        return Task.FromResult(curso);
    }

    public Task<int> ExcluirCursoAsync(int idCurso)
    {
        var cursoEncontrado = _context.Curso.SingleOrDefault(c => c.Id == idCurso);
        if (cursoEncontrado == null)
        {
            throw new Exception($"Curso com ID {idCurso} não encontrado");
        }

        _context.Curso.Remove(cursoEncontrado);
        return _context.SaveChangesAsync();
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) =>
    await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    Task<IEnumerable<CursoEntity>> ICursoRepository.ObtemCursosAsync()
    {
        return _context.Curso
            .ToListAsync()
            .ContinueWith(task => task.Result.AsEnumerable());
    }
}
