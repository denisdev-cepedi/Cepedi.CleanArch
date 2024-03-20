using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface ICursoRepository 
{
    Task<CursoEntity> GetById(int id, CancellationToken cancellationToken);
    Task<IEnumerable<CursoEntity>> GetAll(CancellationToken cancellationToken);
    Task<CursoEntity> Create(CursoEntity curso, CancellationToken cancellationToken);
}