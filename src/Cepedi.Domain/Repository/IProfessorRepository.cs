using Cepedi.BancoCentral.Domain.Entities;

namespace Cepedi.BancoCentral.Domain
{
    public interface IProfessorRepository
    {
        Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId);
        Task<ProfessorEntity> IncluirProfessorAsync(ProfessorEntity professor);
    }
}
