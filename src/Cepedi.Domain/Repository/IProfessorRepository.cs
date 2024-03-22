using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;

namespace Cepedi.Domain
{
    public interface IProfessorRepository
    {
        Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId);
        Task<ProfessorEntity> IncluirProfessorAsync(ProfessorEntity professor);
    }
}