using AutoMapper;
using Cepedi.Domain.Entities;
using Cepedi.Domain.Interfaces;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class AtualizarCursoHandler : IRequestHandler<AtualizarCursoRequest, AtualizarCursoResponse>
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarCursoHandler(ICursoRepository cursoRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _cursoRepository = cursoRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AtualizarCursoResponse> Handle(AtualizarCursoRequest request, CancellationToken cancellationToken)
    {
        var cursodb = _cursoRepository.Search(curso => curso.Id == request.id).FirstOrDefault();

        if (cursodb is null)
            return default;

        var curso = _mapper.Map<CursoEntity>(request);

        cursodb = curso;

        await _cursoRepository.Put(curso);

        await _unitOfWork.Commit(cancellationToken);

        var msg = $"Curso {curso.Nome} atualizado com sucesso !";

        return new AtualizarCursoResponse(msg);
    }
}
