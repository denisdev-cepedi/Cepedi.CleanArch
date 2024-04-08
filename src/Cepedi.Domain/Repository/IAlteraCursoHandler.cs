using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository
{
    public interface IAlteraCursoHandler
    {
        Task<int> AlterarCursoAsync(AlteraCursoRequest curso);
    }
}