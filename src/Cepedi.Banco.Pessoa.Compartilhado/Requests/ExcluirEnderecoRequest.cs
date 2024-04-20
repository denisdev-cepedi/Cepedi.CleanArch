using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Compartilhado.Requests;

public class ExcluirEnderecoRequest : IRequest<Result<ExcluirEnderecoResponse>>
{
    public int EnderecoId { get; set; }
}
