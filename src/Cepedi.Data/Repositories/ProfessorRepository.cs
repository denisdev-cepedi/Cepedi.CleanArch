using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;

namespace Cepedi.Data.Repositories;
public class ProfessorRepository : IProfessorRepository
{
    protected readonly ApplicationDbContext _context;

    public ProfessorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public ICollection<ProfessorEntity> GetAll()
    {
        return _context.Set<ProfessorEntity>().ToList();
    }

    public void Insert(ProfessorEntity professor)
    {
        _context.Set<ProfessorEntity>().Add(professor);
        _context.SaveChanges();
    }
}
