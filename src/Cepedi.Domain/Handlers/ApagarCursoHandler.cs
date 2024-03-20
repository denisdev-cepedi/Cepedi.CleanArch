using AutoMapper;
using Cepedi.Domain.Interfaces;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class ApagarCursoHandler : IRequestHandler<ApagarCursoRequest, ApagarCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ApagarCursoHandler(ICursoRepository cursoRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApagarCursoResponse> Handle(ApagarCursoRequest request, CancellationToken cancellationToken)
    {
        var curso = _cursoRepository.GetById(request.idCurso);

        if (curso is null)
            return default;

        await _cursoRepository.Delete(curso);

        await _unitOfWork.Commit(cancellationToken);

        var msg = $"Curso {curso.Nome} apagado com sucesso !";

        return new ApagarCursoResponse(msg);
    }
}
