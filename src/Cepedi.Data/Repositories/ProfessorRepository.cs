using Cepedi.Domain.Entities;
using Cepedi.Domain.Interfaces;

namespace Cepedi.Data.Repositories;
public class ProfessorRepository : BaseRepository<ProfessorEntity>, IProfessorRepository
{
    public ProfessorRepository(ApplicationDbContext context) : base(context) { }

}
