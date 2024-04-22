using Refit;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Cepedi.Banco.Pessoa.Dominio.Services;
using Cepedi.Compartilhado.Responses;

namespace Cepedi.Banco.Pessoa.Dados.Repositorios.Queries;

public class ServiceExterno
{
    private readonly IServiceExterno _serviceExterno;

    public ServiceExterno(IServiceExterno serviceExterno)
    {
        _serviceExterno = serviceExterno;
    }

    public async Task<EnderecoCepResponse> ObterEnderecoPorCepExternoAsync(string cep)
    {
        var endereco = await _serviceExterno.ObterEnderecoPorCepExternoAsync(cep);
        return endereco.Content;     
    }
    

}
