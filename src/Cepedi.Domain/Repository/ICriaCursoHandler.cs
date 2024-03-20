using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain.Repository
{
    public interface ICriaCursoHandler
    {
         Task<int> CriarCursoAsync(CriaCursoRequest request);
    }
}