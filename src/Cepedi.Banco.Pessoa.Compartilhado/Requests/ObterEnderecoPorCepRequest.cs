using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Compartilhado.Requests;

public class ObterEnderecoPorCepRequest : IRequest<Result<ObterEnderecoPorCepResponse>>
{
    public string Cep { get; set; } = default!;
}
