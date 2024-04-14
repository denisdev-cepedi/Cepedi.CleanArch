using Cepedi.Compartilhado.Requests;
using Refit;

namespace Cepedi.Dominio.Services;
public interface IServico
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] SolicitaDadosRequest notificacao);
}
