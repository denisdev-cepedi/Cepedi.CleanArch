using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Compartilhado.Requests;

public class ObterEnderecoRequest : IRequest<Result<ObterEnderecoResponse>>
{
    public int EnderecoId { get; set; }
}
