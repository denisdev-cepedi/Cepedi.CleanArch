using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable;
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
    private readonly ApplicationDbContext _context;
    private readonly ICriarCursoHandler _criaCursoHandler;
    private readonly IAlterarCursoHandler _alterarCursoHandler;
    private readonly IDeletarCursoHandler _deletarCursoHandler;
    public CursoController(ILogger<CursoController> logger,
    IObtemCursoHandler obtemCursoHandler, ICriarCursoHandler criaCursoHandler, IAlterarCursoHandler AlterarCursoHandler, IDeletarCursoHandler deletarCursoHandler)
    {
        _logger = logger;
        _obtemCursoHandler = obtemCursoHandler;
        _criaCursoHandler = criaCursoHandler;
        _alterarCursoHandler = AlterarCursoHandler;
        _deletarCursoHandler = deletarCursoHandler;
    }

    [HttpGet("{idCurso}")]
    public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
    {
        return Ok(await _obtemCursoHandler.ObterCursoAsync(idCurso));
    }

    [HttpPost("/CriarCurso")]
    public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriarCursoRequest request)
    {
        var cursoId = await _criaCursoHandler.CriarCursoAsync(request);
        return Ok(cursoId);
    }

    [HttpPut("/AlterarCurso/{idCurso}")]
    public async Task<ActionResult<int>> AlterarCursoAsync([FromRoute] int idCurso, [FromBody] AlterarCursoRequest request)
    {
        var cursoAlterado = await _alterarCursoHandler.AlterarCursoAsync(request);
        return Ok(cursoAlterado);
    }

    [HttpDelete("/DeletarCurso/{idCurso}")]
    public async Task<ActionResult<int>> DeletarCursoAsync([FromRoute] int idCurso)
    {
        var deletado = await _deletarCursoHandler.DeletarCursoAsync(idCurso);
        return default(int);
    }
}
