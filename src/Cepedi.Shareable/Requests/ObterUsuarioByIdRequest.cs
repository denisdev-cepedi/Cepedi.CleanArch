using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;

public class ObterUsuarioByIdRequest : IRequest<ObterUsuarioByIdResponse>
{
    public int Id { get; set; }
}