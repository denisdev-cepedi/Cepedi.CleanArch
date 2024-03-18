using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Cepedi.Data;

namespace Cepedi.Shareable.Handlers;
internal class ObtemCursoHandler : IRequestHandler<ObtemCursoRequest, ObtemCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;

    public ObtemCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<ObtemCursoResponse> Handle(ObtemCursoRequest request)
    {
        var response = await _cursoRepository.GetById(request.idCurso);

        return response;
    }
}
