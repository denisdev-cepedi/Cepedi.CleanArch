using Cepedi.Domain;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.WebApi.Controllers
{
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
        public async Task<ActionResult<ObtemCursoResponse>> ObterCursoAsync([FromRoute] int idCurso)
        {
            try
            {
                var curso = await _obtemCursoHandler.ObterCursoAsync(idCurso);
                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao consultar o curso");
                return StatusCode(500, "Ocorreu um erro interno ao consultar o curso");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ObterCursosAsync()
        {
            try
            {
                var cursos = await _obtemCursoHandler.ObterCursosAsync();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao listar os cursos");
                return StatusCode(500, "Ocorreu um erro interno ao listar os cursos");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriaCursoRequest request)
        {
            try
            {
                var novoCursoId = await _criaCursoHandler.CriarCursoAsync(request);
                return CreatedAtAction(nameof(ObterCursoAsync), new { idCurso = novoCursoId }, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao criar o curso");
                return StatusCode(500, "Ocorreu um erro interno ao criar o curso");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Solicitação inválida");
                }

                await _alteraCursoHandler.AlterarCursoAsync(request);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro ao atualizar o curso");
                return StatusCode(500, "Ocorreu um erro interno ao atualizar o curso");
            }
        }
    }
}
