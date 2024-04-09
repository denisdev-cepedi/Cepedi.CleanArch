using Cepedi.Domain.Entities;

namespace Cepedi.Domain;

public interface IProfessorRepository
{
    Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId);
}
