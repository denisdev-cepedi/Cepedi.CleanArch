using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterTodosEnderecosRequestHandler : IRequestHandler<ObterTodosEnderecosRequest, Result<ObterTodosEnderecosResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<ObterTodosEnderecosRequestHandler> _logger;
    public ObterTodosEnderecosRequestHandler(IEnderecoRepository enderecoRepository, ILogger<ObterTodosEnderecosRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<ObterTodosEnderecosResponse>> Handle(ObterTodosEnderecosRequest request, CancellationToken cancellationToken)
    {
        var enderecos = await _enderecoRepository.ObterTodosEnderecosAsync();
        return Result.Success(new ObterTodosEnderecosResponse()
        {
            Enderecos = enderecos.Select(endereco => new ObterEnderecoResponse()
            {
                Id = endereco.Id,
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Uf = endereco.Uf,
                Pais = endereco.Pais,
                Numero = endereco.Numero
            }).ToList()
        });
    }
}
