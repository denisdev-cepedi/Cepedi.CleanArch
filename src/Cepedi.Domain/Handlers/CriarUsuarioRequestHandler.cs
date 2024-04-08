using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class CriarUsuarioRequestHandler : IRequestHandler<CriarUsuarioRequest, CriarUsuarioResponse>
{
    private readonly ILogger<CriarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<CriarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<CriarUsuarioResponse> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
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

            return new CriarUsuarioResponse(usuario.Id, usuario.Nome);

        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            throw;
        }
    }
}
