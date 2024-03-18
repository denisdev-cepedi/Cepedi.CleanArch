using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;
public interface ICursoRepository
{
    void Insert(CursoEntity curso);
    ICollection<CursoEntity> GetAll();
}