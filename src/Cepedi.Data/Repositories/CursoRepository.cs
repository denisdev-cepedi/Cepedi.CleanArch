using Cepedi.Domain.Interfaces;
using Cepedi.Domain.Entities;

namespace Cepedi.Data.Repositories;
public class CursoRepository : BaseRepository<CursoEntity>, ICursoRepository
{
    public CursoRepository(ApplicationDbContext context) : base(context) { }

}
