using Cepedi.Domain.Repository;
using Cepedi.Shareable.Enums;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Domain.Handlers;

public class ObtemCursoRequestHandler : IRequestHandler<ObtemCursoRequest, Result<ObtemCursoResponse>>
{
    private readonly ILogger<ObtemCursoRequestHandler> _logger;
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemCursoRequestHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository, ILogger<ObtemCursoRequestHandler> logger)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
        _logger = logger;
    }

    public async Task<Result<ObtemCursoResponse>> Handle(ObtemCursoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("ObtemCursoRequestHandler.cs: ObtemCursoRequestHandler.Handle() called.", request.IdCurso);
            var curso = await _cursoRepository.ObtemCursoPorIdAsync(request.IdCurso);
            var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
            var horario = $"{curso.DataInicio} - {curso.DataFim}";
            return Result.Success(new ObtemCursoResponse(curso.Id, curso.Nome, horario, professor.Nome));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao obter um curso");
            return Result.Error<ObtemCursoResponse>(new Shareable.Exceptions.ApplicationException(
                (CepediMensagemError.SemResultados)));
        }
    }
}
