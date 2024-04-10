using Cepedi.Shareable.Requests;
using Refit;

namespace Cepedi.Domain.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] SolicitaDadosRequest notificacao);
}
