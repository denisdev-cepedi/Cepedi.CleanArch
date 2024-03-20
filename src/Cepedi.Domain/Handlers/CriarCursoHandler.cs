using AutoMapper;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Interfaces;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class CriarCursoHandler : IRequestHandler<CriarCursoRequest, CriarCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CriarCursoHandler(ICursoRepository cursoRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CriarCursoResponse> Handle(CriarCursoRequest request, CancellationToken cancellationToken)
    {
        var curso = _mapper.Map<CursoEntity>(request);

        await _cursoRepository.Post(curso);

        await _unitOfWork.Commit(cancellationToken);

        var msg = $"Curso {curso.Nome} criado com sucesso !";

        return new CriarCursoResponse(msg);
    }
}
