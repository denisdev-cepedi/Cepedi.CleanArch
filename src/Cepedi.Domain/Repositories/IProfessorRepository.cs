
using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repositories
{
    public interface IProfessorRepository
    {
        void Insert(ProfessorEntity professor);
        ICollection<ProfessorEntity> GetAll();
    }
}