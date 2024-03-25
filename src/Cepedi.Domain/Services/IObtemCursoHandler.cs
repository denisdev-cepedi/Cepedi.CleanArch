using Cepedi.Shareable.Responses;

namespace Cepedi.Domain;

public interface IObtemCursoHandler
{
    Task<ObtemCursoResponse> ObterCursoAsync(int idCurso);
}
