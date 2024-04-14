using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Compartilhado.Requests;

namespace Cepedi.Dominio.Repository
{
    public interface IAlteraCursoHandler
    {
        Task<int> AlterarCursoAsync(AlteraCursoRequest request);
    }
}
