using Cepedi.Data.Repositories.Interfaces;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CursoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CursoEntity> GetById(int id)
    {
        return await _dbContext.Curso.FirstOrDefaultAsync(curso => curso.Id == id);
    }
}
