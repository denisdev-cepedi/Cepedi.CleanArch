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

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ObtemCursoRequest(idCurso), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CriarCursoResponse>> CriarCursoAsync(CriarCursoRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AtualizarCursoResponse>> Update(int id, AtualizarCursoRequest request, CancellationToken cancellationToken)
    {
        if (id != request.id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int? id, CancellationToken cancellationToken)
    {
        if (id is null)
            return BadRequest();

        var request = new ApagarCursoRequest(id.Value);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}
