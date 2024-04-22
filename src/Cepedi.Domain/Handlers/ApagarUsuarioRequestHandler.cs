using MediatR;
using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.BancoCentral.Domain.Repository;
namespace Cepedi.BancoCentral.Domain.Handlers;
public class ApagarUsuarioRequestHandler : IRequestHandler<ApagarCursoRequest, ApagarCursoResponse>
{
    private readonly IUsuarioRepository _repository;
     private readonly ILogger<ApagarUsuarioRequestHandler> _logger;
     public ApagarUsuarioRequestHandler(IUsuarioRepository repository, ILogger<ApagarUsuarioRequestHandler> logger){
         _repository = repository;
         _logger = logger;
     }
     public async Task<ApagarCursoResponse> Handle(ApagarCursoRequest request, CancellationToken cancellationToken){
        
     }
}