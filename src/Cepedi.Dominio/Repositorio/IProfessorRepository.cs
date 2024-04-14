using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Dominio.Entidades;

namespace Cepedi.Dominio
{
    public interface IProfessorRepository
    {
        Task<ProfessorEntity> ObtemProfessorPorIdAsync(int professorId);
        Task<ProfessorEntity> IncluirProfessorAsync(ProfessorEntity professor);
    }
}