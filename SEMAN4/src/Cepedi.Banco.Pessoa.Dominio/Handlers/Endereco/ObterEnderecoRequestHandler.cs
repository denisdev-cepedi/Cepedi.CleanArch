using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterEnderecoRequestHandler : IRequestHandler<ObterEnderecoRequest, Result<ObterEnderecoResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<ObterEnderecoRequestHandler> _logger;
    public ObterEnderecoRequestHandler(IEnderecoRepository enderecoRepository, ILogger<ObterEnderecoRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }
    public async Task<Result<ObterEnderecoResponse>> Handle(ObterEnderecoRequest request, CancellationToken cancellationToken)
    {
        var endereco = await _enderecoRepository.ObterEnderecoAsync(request.EnderecoId);
        if (endereco == null)
        {
            return Result.Error<ObterEnderecoResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        return Result.Success(new ObterEnderecoResponse()
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
