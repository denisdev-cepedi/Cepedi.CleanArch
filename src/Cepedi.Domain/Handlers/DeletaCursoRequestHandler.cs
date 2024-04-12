using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable;
using Cepedi.Shareable.Enums;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Domain.Handlers;

public class DeletaCursoRequestHandler : IRequestHandler<DeletaCursoRequest, Result<DeletaCursoResponse>>
{
    private readonly ILogger<DeletaCursoRequestHandler> _logger;
    private readonly ICursoRepository _cursoRepository;

    public DeletaCursoRequestHandler(ICursoRepository cursoRepository, ILogger<DeletaCursoRequestHandler> logger)
    {
        _logger = logger;
        _cursoRepository = cursoRepository;
    }

    public async Task<Result<DeletaCursoResponse>> Handle(DeletaCursoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var curso = await _cursoRepository.DeletaCursoAsync(request.IdCurso);

            return Result.Success(new DeletaCursoResponse(curso.Id));
           
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro ao deletar um curso");
            return Result.Error<DeletaCursoResponse>(new Shareable.Exceptions.ApplicationException(
                (CepediMensagemError.ErroGravacaoUsuario)));     
        }
    }
}