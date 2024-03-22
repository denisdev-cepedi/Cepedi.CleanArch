using Cepedi.Domain.Entities;

namespace Cepedi.Domain.Repository;

public interface IProfessorRepository
{
    Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId);
}
