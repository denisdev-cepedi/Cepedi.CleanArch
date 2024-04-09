using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class ObterUsuarioRequestHandler : IRequestHandler<ObterUsuarioRequest, ObterUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioRequestHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ObterUsuarioResponse> Handle(ObterUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var id = request;
            var usuario = await _usuarioRepository.ObterUsuarioAsync(1);

            return new ObterUsuarioResponse(usuario.Id, usuario.Nome, usuario.Email, usuario.DataNascimento.ToString(), usuario.Celular);

        }catch
        {
            throw;
        }
    }
}
