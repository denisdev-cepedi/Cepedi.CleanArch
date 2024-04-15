using Cepedi.Compartilhado.Responses;
using MediatR;
using OperationResult;

namespace Cepedi.Compartilhado.Requests;
public class CriarUsuarioRequest : IRequest<Result<CriarUsuarioResponse>>
{
    public string Nome { get; set; } = default!;

    public DateTime DataNascimento { get; set; }

    public string Cpf { get; set; } = default!;

    public string Celular { get; set; } = default!;

    public bool CelularValidado { get; set; }

    public string Email { get; set; } = default!;
}
