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
        throw new NotImplementedException();
    }
}
