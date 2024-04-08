using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository
{
    public interface ICriarCursoHandler
    {
         Task<int> CriarCursoAsync(CriarCursoRequest request);
    }
}