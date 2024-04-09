using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;

public class DeletarUsuarioByIdRequest : IRequest
{
    public int Id { get; set; }
}