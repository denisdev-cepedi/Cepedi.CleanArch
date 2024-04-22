using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterEnderecoPorCepRequestHandler : IRequestHandler<ObterEnderecoPorCepRequest, Result<ObterEnderecoPorCepResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<ObterEnderecoPorCepRequestHandler> _logger;
    public ObterEnderecoPorCepRequestHandler(IEnderecoRepository enderecoRepository, ILogger<ObterEnderecoPorCepRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }
    public async Task<Result<ObterEnderecoPorCepResponse>> Handle(ObterEnderecoPorCepRequest request, CancellationToken cancellationToken)
    {
        var endereco = await _enderecoRepository.ObterEnderecoPorCepAsync(request.Cep);
        if (endereco == null)
        {
            return Result.Error<ObterEnderecoPorCepResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        return Result.Success(new ObterEnderecoPorCepResponse()
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
        });
    }
}
