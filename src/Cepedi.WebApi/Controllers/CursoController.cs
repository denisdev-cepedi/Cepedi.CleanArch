using Cepedi.Domain;
using Cepedi.Domain.Repository;
using Cepedi.IoC;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
    public async Task<ActionResult<CriarCursoResponse>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        return await _mediator.Send(request);
    }

    // [HttpPut]
    // public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    // {
    //     var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
    //     return Ok(cursoId);
    // }

    // [HttpDelete("{idCurso}")]
    // public async Task<ActionResult<int>> ExcluirCursoAsync([FromRoute] int idCurso)
    // {
    //     var cursoId = await _excluiCursoHandler.ExcluirCursoAsync(idCurso);
    //     return Ok(cursoId);
    // }
}
