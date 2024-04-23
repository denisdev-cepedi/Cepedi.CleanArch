using Refit;
using System.Net.Http.Json;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Cepedi.Banco.Pessoa.Dominio.Services;
using Cepedi.Compartilhado.Responses;
using System.Net;
using System.Text.Json;
using OperationResult;
using Cepedi.Banco.Pessoa.Compartilhado.Exceptions;
using Cepedi.Banco.Pessoa.Compartilhado.Enums;


namespace Cepedi.Banco.Pessoa.Dados.Repositorios.Queries;

public class ServiceExterno : IServiceExterno
{
    public Task<ApiResponse<HttpResponseMessage>> EnviarNotificacao([Body] object notificacao)
    {
        throw new NotImplementedException();
    }

    public async Task<EnderecoCepResponse> ObterEnderecoPorCepExternoAsync(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
                throw new Exception($"Erro ao consultar o serviço externo: {response.StatusCode} - {response.ReasonPhrase}"); 
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<EnderecoCepResponse>(responseContent)!;
    }
}