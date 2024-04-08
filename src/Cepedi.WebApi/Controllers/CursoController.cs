using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    // [HttpGet("{idCurso}")]
    // public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    // {
    //     return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    // }

    // // [HttpGet]
    // // public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ObterCursosAsync()
    // // {
    // //     var cursos = await _obtemCursoHandler.ObterCursosAsync();
    // //     return Ok(cursos);
    // // }

    [HttpPost]
    [ProducesResponseType(typeof(CriarCursoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarCursoResponse>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        return await _mediator.Send(request);
    }
    // // // [HttpPut]
    // // // public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    // // // {
    // // //     var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
    // // //     return Ok(cursoId);
    // // // }
    // // // [HttpDelete("{idCurso}")]
    // // // public async Task<ActionResult<int>> ExcluirCursoAsync([FromRoute] int idCurso)
    // // // {
    // // //     var cursoId = await _excluirCursoHandler.ExcluirCursoAsync(idCurso);
    // // //     return Ok(cursoId);
    // // // }
}
