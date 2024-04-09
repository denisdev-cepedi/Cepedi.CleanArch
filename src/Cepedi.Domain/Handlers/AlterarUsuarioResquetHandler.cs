using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class AlterarUsuarioRequestHandler : IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AlterarUsuarioRequestHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AlterarUsuarioResponse> Handle(AlterarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = await _usuarioRepository.ObterUsuarioAsync(request.Id);
            if(usuario == null) throw new NotImplementedException();

            usuario.Celular = request.Celular;
            usuario.CelularValidado = request.CelularValidado;
            usuario.Cpf = request.Cpf;
            usuario.DataNascimento = request.DataNascimento;
            usuario.Email = request.Email;
            usuario.Nome = request.Nome;
            
            await _usuarioRepository.AlterarUsuarioAsync(usuario);

            return new AlterarUsuarioResponse(usuario.Id, usuario.Nome);

        }catch
        {
            throw;
        }
    }
}
