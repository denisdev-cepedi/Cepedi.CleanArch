using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;

namespace Cepedi.Data.Repositories;
public class CursoRepository : ICursoRepository
{
    protected readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public ICollection<CursoEntity> GetAll()
    {
        return _context.Set<CursoEntity>().ToList();
    }

    public void Insert(CursoEntity curso)
    {
        _context.Set<CursoEntity>().Add(curso);
        _context.SaveChanges();
    }
}
