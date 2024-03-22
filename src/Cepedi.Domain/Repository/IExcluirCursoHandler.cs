using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.Domain.Repository
{
    public interface IExcluirCursoHandler
    {
            Task<int> ExcluirCursoAsync(int idCurso);
    }
}