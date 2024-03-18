using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Cepedi.Data.Repositories;

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
        var response = await _cursoRepository;

        return _mapper.Map<List<GetAllUserResponse>>(response);
    }
}
