using Cepedi.Shareable.Responses;
using Cepedi.Shareable.Requests;
using Microsoft.AspNetCore.Mvc;
using Cepedi.Domain.Services;
using MediatR;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable;
using OperationResult;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : BaseController
{
    private readonly ILogger<CursoController> _logger;
    private readonly IMediator _mediator;

    public CursoController(
        ILogger<CursoController> logger, 
        IMediator mediator)
        : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{IdCurso}")]
    [ProducesResponseType(typeof(ObtemCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] ObtemCursoRequest request)
    {
        return await SendCommand(request);
    }         

    [HttpGet]
    [ProducesResponseType(typeof(ObtemCursosResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ObtemCursosResponse>> ConsultarCursosAsync( [FromRoute] ObtemCursosRequest request)
    {
         return await SendCommand(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CriaCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriaCursoResponse>> CriaCursoAsync([FromBody] CriaCursoRequest request)
    {
         return await SendCommand(request);
    }

    [HttpPut("{IdCurso}")]
    [ProducesResponseType(typeof(AtualizaCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AtualizaCursoResponse>> AtualizaCursoAsync([FromRoute] AtualizaCursoRequest request)
    {
         return await SendCommand(request);
    }

    [HttpDelete("{IdCurso}")]
    [ProducesResponseType(typeof(DeletaCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeletaCursoResponse>> DeletaCursoAsync([FromRoute] DeletaCursoRequest request)
    {
        return await SendCommand(request);
    }

}
