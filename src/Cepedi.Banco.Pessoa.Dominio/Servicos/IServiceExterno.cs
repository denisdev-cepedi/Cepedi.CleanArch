﻿using Cepedi.Compartilhado.Responses;
using Refit;

namespace Cepedi.Banco.Pessoa.Dominio.Services;
public interface IServiceExterno
{
    [Post("api/v1/Enviar")]
    Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao);

    [Get("/ws/{cep}/json/")]
    Task<ApiResponse<EnderecoCepResponse>> ObterEnderecoPorCepExternoAsync(string cep);
}
