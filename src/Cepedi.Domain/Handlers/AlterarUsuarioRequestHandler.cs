using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class AlterarUsuarioRequestHandler : IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
{
    private readonly ILogger<AlterarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public AlterarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<AlterarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<AlterarUsuarioResponse> Handle(AlterarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = new UsuarioEntity()
            {
                Id = request.Id,
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Celular = request.Celular,
                CelularValidado = request.CelularValidado,
                Email = request.Email,
                Cpf = request.Cpf
            };

            await _usuarioRepository.AlterarUsuarioAsync(usuario);

            return new AlterarUsuarioResponse(usuario.Id, usuario.Nome);

        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            throw;
        }
    }
}
