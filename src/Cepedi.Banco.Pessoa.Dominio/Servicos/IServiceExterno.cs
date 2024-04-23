using Cepedi.Compartilhado.Responses;
using OperationResult;
using Refit;

namespace Cepedi.Banco.Pessoa.Dominio.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao);

    [Get("api/endereco/{cep}")]
    Task<EnderecoCepResponse> ObterEnderecoPorCepExternoAsync(string cep);
}
