using Cepedi.Data;
using Cepedi.Data.Repositories;
using Cepedi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Namespace;
public class CursoRepository : BaseRepository<CursoEntity>, ICursoRepository
{
    public CursoRepository(ApplicationDbContext context) : base(context)
    {
    }
}
