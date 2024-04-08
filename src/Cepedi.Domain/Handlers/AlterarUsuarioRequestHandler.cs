using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;
public class AlterarUsuarioRequestHandler : IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
{
    private readonly ILogger<CriarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public AlterarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<CriarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<AlterarUsuarioResponse> Handle(AlterarUsuarioRequest request, CancellationToken cancellationToken)
    {
       
       
        try
        {   
            var usuarioEntity = await _usuarioRepository.GetUsuarioById(request.Id);
           //premissa do DDD
           if (usuarioEntity == null){
               throw new Exception("Usário não encontrado");
           }
            usuarioEntity.Atualizar(usuarioEntity.Id, usuarioEntity.DataNascimento, usuarioEntity.Celular, usuarioEntity.CelularValidado, usuarioEntity.Email, usuarioEntity.Cpf);
           

            await _usuarioRepository.AlterarUsuarioAsync(usuarioEntity);

            return new AlterarUsuarioResponse(usuarioEntity.Id, usuarioEntity.Nome);

        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            throw;
        }
    }
}
