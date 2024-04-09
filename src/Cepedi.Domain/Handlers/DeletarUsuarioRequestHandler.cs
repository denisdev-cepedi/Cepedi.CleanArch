using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class DeletarUsuarioRequestHandler : IRequestHandler<DeletarUsuarioRequest, DeletarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioRequestHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<DeletarUsuarioResponse> Handle(DeletarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _usuarioRepository.ObterUsuarioAsync(request.Id);

            return new DeletarUsuarioResponse();

        }catch
        {
            throw;
        }
    }
}
