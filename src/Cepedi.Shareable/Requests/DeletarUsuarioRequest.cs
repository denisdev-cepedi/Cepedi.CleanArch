using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class DeletarUsuarioRequest : IRequest<DeletarUsuarioResponse>
{
    public int Id { get; set; }
    
}
