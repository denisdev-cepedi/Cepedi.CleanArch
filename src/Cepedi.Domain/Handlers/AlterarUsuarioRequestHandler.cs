using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.BancoCentral.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers
{
    public class AlterarUsuarioRequestHandler :
     IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
    {
        private readonly ILogger<AlterarUsuarioRequestHandler> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

            public AlterarUsuarioRequestHandler(
                IUsuarioRepository usuarioRepository, 
                ILogger<AlterarUsuarioRequestHandler> logger)
            {
                _usuarioRepository = usuarioRepository;
                _logger = logger;
            }
            
            public async Task<AlterarUsuarioResponse> Handle(
                AlterarUsuarioRequest request, 
                CancellationToken cancellationToken)
            {
                var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(request.Id);
                if (usuario == null){
                    throw new Exception("Usuario não encontrado");
                }

                usuario.Atualizar(request.Nome);

                await _usuarioRepository.AlterarUsuarioAsync(usuario);
                return new AlterarUsuarioResponse(usuario.Nome);
            }

    }
}