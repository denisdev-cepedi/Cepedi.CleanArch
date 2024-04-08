using Cepedi.Domain;
using Cepedi.Domain.Repository;
using Cepedi.IoC;
using Cepedi.Shareable.Exceptions;
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

    public CursoController(
        ILogger<CursoController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    // [HttpGet("{idCurso}")]
    // public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    // {
    //     return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    // }
    // [HttpGet()]
    // public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
    // {
    //     return Ok(await _obtemCursoHandler.ObterCursosAsync());
    // }
    [HttpPost]
    [ProducesResponseType(typeof(ObtemCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObtemCursoResponse>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        return await _mediator.Send(request);
    }


    // [HttpPut]
    // public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    // {
    //     var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
    //     return Ok(cursoId);
    // }
}
