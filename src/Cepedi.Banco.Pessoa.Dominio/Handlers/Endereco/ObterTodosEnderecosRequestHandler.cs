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
        throw new NotImplementedException();
    }
}
