using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Microsoft.Extensions.Logging;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using OperationResult;
using Cepedi.Shareable.Enums;

namespace Cepedi.Domain.Handlers;

public class CriaCursoRequestHandler : IRequestHandler<CriaCursoRequest, Result<CriaCursoResponse>>
{
    private readonly ILogger<CriaCursoRequestHandler> _logger;
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CriaCursoRequestHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository, ILogger<CriaCursoRequestHandler> logger)
    {
        _logger = logger;
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<Result<CriaCursoResponse>> Handle(CriaCursoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var curso = new CursoEntity
            {
                Nome = request.Nome,
                Descricao = request.Descricao ?? default!,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ProfessorId = request.ProfessorId
            };

            _ = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);

            var cursoCriado = await _cursoRepository.CriaNovoCursoAsync(curso);

            return Result.Success(new CriaCursoResponse(cursoCriado.Id));
        }
        catch (Exception)
        {
            _logger.LogError("Ocorreu um erro ao criar um novo curso");
            return Result.Error<CriaCursoResponse>(new Shareable.Exceptions.ApplicationException(
                (CepediMensagemError.ErroGravacaoUsuario)));
        }
    }

}
