using Cepedi.Domain.Repository;
using Cepedi.Shareable.Enums;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Domain.Handlers;

public class ObtemCursosRequestHandler : IRequestHandler<ObtemCursosRequest, Result<ObtemCursosResponse>>
{
    public readonly ILogger<ObtemCursosRequestHandler> _logger;
    public readonly ICursoRepository _cursoRepository;
    public readonly IProfessorRepository _professorRepository;

    public ObtemCursosRequestHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository, ILogger<ObtemCursosRequestHandler> logger)
    {
        _logger = logger;
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<Result<ObtemCursosResponse>> Handle(ObtemCursosRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var cursos = await _cursoRepository.ObtemCursosAsync();
            
            var cursoReponse = new List<ObtemCursoResponse>();
            foreach (var curso in cursos)
            {
                var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
                cursoReponse.Add(new ObtemCursoResponse(curso.Id, curso.Nome, $"{curso.DataInicio} - {curso.DataFim}", professor.Nome));
            }
            

            return Result.Success(new ObtemCursosResponse(cursoReponse));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao obter os cursos");
            return Result.Error<ObtemCursosResponse>(new Shareable.Exceptions.ApplicationException(
                (CepediMensagemError.SemResultados)));
        }
    }
}
