using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioRequest, AtualizarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AtualizarUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AtualizarUsuarioResponse> Handle(AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = new UsuarioEntity()
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Celular = request.Celular,
                CelularValidado = request.CelularValidado,
                Email = request.Email,
                Cpf = request.Cpf
            };

            await _usuarioRepository.CriarUsuarioAsync(usuario);

            return new AtualizarUsuarioResponse(usuario.Id, usuario.Nome);

        }catch
        {
            throw;
        }
    }

}
