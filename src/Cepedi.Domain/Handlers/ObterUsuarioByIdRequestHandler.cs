using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;

public class ObterUsuarioByIdRequestHandler : IRequestHandler<ObterUsuarioByIdRequest, ObterUsuarioByIdResponse>
{
    private readonly ILogger<CriarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioByIdRequestHandler(IUsuarioRepository usuarioRepository, ILogger<CriarUsuarioRequestHandler> logger){
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<ObterUsuarioByIdResponse> Handle(ObterUsuarioByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuarioEntity = await _usuarioRepository.GetUsuarioById(request.Id);
            if (usuarioEntity == null)
            {
                throw new Exception("Usário não encontrado");
            }
            return new ObterUsuarioByIdResponse(usuarioEntity.Id, usuarioEntity.Nome, usuarioEntity.DataNascimento, usuarioEntity.Cpf, usuarioEntity.Celular, usuarioEntity.CelularValidado, usuarioEntity.Email);  

        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            throw;
        }
    }

}