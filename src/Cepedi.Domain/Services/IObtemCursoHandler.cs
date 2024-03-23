using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IObtemCursoHandler
{
    Task<ObtemCursoResponse> ObtemCursoAsync(int id);
    Task<IEnumerable<ObtemCursoResponse>> ObtemCursosAsync();    
}
