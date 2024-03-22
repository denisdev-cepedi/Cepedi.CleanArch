using Cepedi.Shareable;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IObtemCursoHandler
{
    Task<ObtemCursoResponse> ObterCursoAsync(int idCurso);
}