using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable;
using Cepedi.Shareable.Enums;
using Cepedi.Shareable.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Domain.Handlers;

public class AtualizaCursoRequestHandler : IRequestHandler<AtualizaCursoRequest, Result<AtualizaCursoResponse>>
{
    private readonly ILogger<AtualizaCursoRequestHandler> _logger;
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public AtualizaCursoRequestHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository, ILogger<AtualizaCursoRequestHandler> logger)
    {
        _logger = logger;
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<Result<AtualizaCursoResponse>> Handle(AtualizaCursoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.IdCurso);

            var professor = await _professorRepository.ObtemProfessorPorIdAsync(request.ProfessorId);

            if (professor == null)
            {
                throw new KeyNotFoundException($"Professor com id {request.ProfessorId} não.");
            }

            curso.Nome = request.Nome;
            curso.Descricao = request.Descricao ?? default!;
            curso.DataInicio = request.DataInicio;
            curso.DataFim = request.DataFim;
            curso.ProfessorId = request.ProfessorId;

            var cursoAtualizado = await _cursoRepository.AtualizaCursoAsync(curso);

            return Result.Success(new AtualizaCursoResponse(cursoAtualizado.Id));
        }
        catch (Exception)
        {
            _logger.LogError("Ocorreu um erro ao atualizar um curso");
            return Result.Error<AtualizaCursoResponse>(new Shareable.Exceptions.ApplicationException(
                (CepediMensagemError.ErroGravacaoUsuario)));
        }
    }

}
