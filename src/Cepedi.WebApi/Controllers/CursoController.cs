using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IMediator _mediator;

    public CursoController(ILogger<CursoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("curso")]
    public async Task<ActionResult<ObtemCursoResponse>> ObterCursoAsync([FromQuery] ObtemCursoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result as ObtemCursoResponse);
    }

    [HttpPost]
    public async Task<ActionResult<CriaCursoResponse>> CriarCursoAsync([FromBody] CriaCursoRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPut]
    public async Task<ActionResult<IncluirCursoResponse>> AtualizarCursoAsync([FromBody] AlteraCursoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result as IncluirCursoResponse);
    }

    // [HttpDelete]
    // public async Task<ActionResult<ExcluiCursoResponse>> ExcluirCursoAsync([FromBody] ExcluiCursoRequest request)
    // {
    //     return await _mediator.Send(request);
    // }
}
