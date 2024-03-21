using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

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
    public Task<int> AddCursoDbAsync(CursoEntity entity)
    {
        _context.Curso.Add(entity);
        return _context.SaveChangesAsync();
    }

    public async Task<CursoEntity> AlterarCursoDbAsync(CursoEntity entity)
    {
        _context.Curso.Update(entity);
        await _context.SaveChangesAsync();
        return ObtemCursoPorIdAsync(entity.Id).Result;
    }

    public async Task<CursoEntity> DeletarCursoDbAsync(CursoEntity entity){
        _context.Curso.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
