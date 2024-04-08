using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Repository;

public interface IObtemCursoHandler
{
    public Task<ObtemCursoResponse> ObterCursoAsync(int idCurso);
    public Task<IEnumerable<ObtemCursoResponse>> ObterCursosAsync();
}
