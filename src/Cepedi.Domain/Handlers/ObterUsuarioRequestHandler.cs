using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;

using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class ObterUsuarioRequestHandler : IRequestHandler<ObterUsuarioRequest, ObterUsuarioResponse>
{
    private readonly ILogger<ObterUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<ObterUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }


    public  Task<List<ObterUsuarioResponse>> Handle(ObterUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuarios = _usuarioRepository.ObterUsuarios();
        return  usuarios;
    }

}
