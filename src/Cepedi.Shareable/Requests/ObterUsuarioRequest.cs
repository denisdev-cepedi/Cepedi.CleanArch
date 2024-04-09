using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class ObterUsuarioRequest : IRequest<ObterUsuarioResponse>
{
    public int Id { get; set; }
    
}
