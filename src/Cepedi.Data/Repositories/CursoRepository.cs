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

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) => 
    await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    public async Task<CursoEntity> CriaCursoAsync(CursoEntity curso)
    {
        await _context.Curso.AddAsync(curso);
        await _context.SaveChangesAsync();
        return curso;
    }
}
