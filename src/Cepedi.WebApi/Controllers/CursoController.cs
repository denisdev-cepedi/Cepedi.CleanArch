using Cepedi.Domain;
using Cepedi.Domain.Repository;
using Cepedi.IoC;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;

    private readonly ICriaCursoHandler _criaCursoHandler;
    private readonly IAlteraCursoHandler _alteraCursoHandler;

    public CursoController(
        ILogger<CursoController> logger,
        IObtemCursoHandler obtemCursoHandler,
        ICriaCursoHandler criaCursoHandler,
        IAlteraCursoHandler alteraCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _criaCursoHandler = criaCursoHandler;
        _alteraCursoHandler = alteraCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
    {
        return Ok(await _obtemCursoHandler.ObterCursosAsync());
    }
    [HttpPost]
    public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriaCursoRequest request)
    {
        var cursoId = await _criaCursoHandler.CriarCursoAsync(request);
        return Ok(cursoId);
    }
    [HttpPut]
    public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    {
        var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
        return Ok(cursoId);
    }
}
