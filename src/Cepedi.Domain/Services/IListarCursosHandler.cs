using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IListarCursosHandler
{
    Task<IEnumerable<ObtemCursoResponse>> ListarCursosAsync();
}
