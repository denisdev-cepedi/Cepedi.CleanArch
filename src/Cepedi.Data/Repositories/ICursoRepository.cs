using Cepedi.Domain.Entities;

namespace Cepedi.Data.Repositories;

public interface ICursoRepository : IBaseRepository<CursoEntity>
{
    Task<CursoEntity> GetById(int id, CancellationToken cancellationToken);
}