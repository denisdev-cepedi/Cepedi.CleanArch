using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;
public interface IProfessorRepository
{
    void Insert(ProfessorEntity professor);
    ICollection<ProfessorEntity> GetAll();
}
