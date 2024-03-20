using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface IProfessorRepository
{
    Task<ProfessorEntity> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<ProfessorEntity>> GetAll(CancellationToken cancellationToken);
}
