using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.Domain.Handlers;

public class ObterUsuariosRequestHandler : IRequestHandler<ObterUsuariosRequest, List<ObterUsuariosResponse>>
{
    private readonly ILogger<CriarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuariosRequestHandler(IUsuarioRepository usuarioRepository, ILogger<CriarUsuarioRequestHandler> logger){
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<List<ObterUsuariosResponse>> Handle(ObterUsuariosRequest request, CancellationToken cancellationToken)
    {
        try{
            
            var usuarios = await _usuarioRepository.GetUsuariosAsync();
            if (usuarios == null)
            {
                throw new Exception("Usuários não encontrados");
            }
            
            // Perform the mapping from List<UsuarioEntity> to List<ObterUsuariosResponse> here
            List<ObterUsuariosResponse> responseList = new List<ObterUsuariosResponse>();
            foreach(var usuario in usuarios)
            {
                // Perform mapping from UsuarioEntity to ObterUsuariosResponse and add to the list
                responseList.Add(new ObterUsuariosResponse(usuario.Id, usuario.Nome, usuario.DataNascimento, usuario.Cpf, usuario.Celular, usuario.CelularValidado, usuario.Email));
            }
            
            return responseList;

        }catch(Exception ex){
            _logger.LogError("Ocorreu um erro durante a execução: " + ex.Message);
            // Return an empty list or handle the error accordingly
            return new List<ObterUsuariosResponse>();
        }
    }
}