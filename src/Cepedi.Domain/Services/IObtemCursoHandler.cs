using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain
{
    public interface IObtemCursoHandler
    {
        Task<ObtemCursoResponse> ObterCursoAsync(int idCurso);
        Task<IEnumerable<ObtemCursoResponse>> ObterCursosAsync();
    }
}