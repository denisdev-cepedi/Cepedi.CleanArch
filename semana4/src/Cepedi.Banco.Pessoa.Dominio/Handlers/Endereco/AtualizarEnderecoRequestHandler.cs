using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class AtualizarEnderecoRequestHandler : IRequestHandler<AtualizarEnderecoRequest, Result<AtualizarEnderecoResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<AtualizarEnderecoRequestHandler> _logger;
    public AtualizarEnderecoRequestHandler(IEnderecoRepository enderecoRepository, ILogger<AtualizarEnderecoRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }

    public async Task<Result<AtualizarEnderecoResponse>> Handle(AtualizarEnderecoRequest request, CancellationToken cancellationToken)
    {
        var endereco = await _enderecoRepository.ObterEnderecoAsync(request.Id);
        if (endereco == null)
        {
            return Result.Error<AtualizarEnderecoResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        endereco.Atualizar(request);
        await _enderecoRepository.AtualizarEnderecoAsync(endereco);

        return Result.Success(new AtualizarEnderecoResponse()
        {
            Id = endereco.Id,
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Uf = request.Uf,
            Pais = request.Pais,
            Numero = request.Numero
        });
    }
}
