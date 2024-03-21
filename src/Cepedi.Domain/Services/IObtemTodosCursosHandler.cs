using Cepedi.Shareable;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Services;

public interface IObtemTodosCursosHandler
{
    Task<ObtemTodosCursosResponse> ObterTodosCursosAsync();
}
