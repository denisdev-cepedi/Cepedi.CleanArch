using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso)
    {
        return await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();
    }
}
