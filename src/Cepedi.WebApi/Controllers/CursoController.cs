using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
    private readonly ILogger<CursoController> _logger;
    private readonly IObtemCursoHandler _obtemCursoHandler;
    private readonly ICriarCursoHandler _criarCursoHandler;
    private readonly IAlteraCursoHandler _alteraCursoHandler;
    private readonly IExcluirCursoHandler _excluirCursoHandler;
    private readonly ApplicationDbContext _context;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler,
    ICriarCursoHandler criarCursoHandler,
    IAlteraCursoHandler alteraCursoHandler,
    IExcluirCursoHandler excluirCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _criarCursoHandler = criarCursoHandler;
        _alteraCursoHandler = alteraCursoHandler;
        _excluirCursoHandler = excluirCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ObterCursosAsync()
    {
        var cursos = await _obtemCursoHandler.ObterCursosAsync();
        return Ok(cursos);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        var cursoId = await _criarCursoHandler.CriarCursoAsync(request);
        return Ok(cursoId);
    }
    [HttpPut]
    public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
    {
        var cursoId = await _alteraCursoHandler.AlterarCursoAsync(request);
        return Ok(cursoId);
    }
    [HttpDelete("{idCurso}")]
    public async Task<ActionResult<int>> ExcluirCursoAsync([FromRoute] int idCurso)
    {
        var cursoId = await _excluirCursoHandler.ExcluirCursoAsync(idCurso);
        return Ok(cursoId);
    }
}
