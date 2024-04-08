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

    [HttpPost]
    [ProducesResponseType(typeof(CriarCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarCursoResponse>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        //var cursoId = await _criaCursoHandler.CriarCursoAsync(request);
        return await _mediator.Send(request);
    }

    
   /*  [HttpGet()]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
    {
        return Ok(await _obtemCursoHandler.ObterCursosAsync());
    } */

   /*  [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPut]
    public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    {
        var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
        return Ok(cursoId);
    } */
}
