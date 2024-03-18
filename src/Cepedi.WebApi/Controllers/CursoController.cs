using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Cepedi.Domain.Entities;

namespace Cepedi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{idCurso}")]
        public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
        {
            // Implementação da operação GET (ConsultarCursoAsync)
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CriarCursoAsync([FromBody] int idCurso, [FromBody] int curso)
        {
            // Implementação da operação POST (CriarCursoAsync)
            return Ok();
        }

        [HttpPut("{idCurso}")]
        public async Task<ActionResult> AtualizarCursoAsync([FromRoute] int idCurso, [FromBody] int curso)
        {
            // Implementação da operação PUT (AtualizarCursoAsync)
            return Ok();
        }

        [HttpDelete("{idCurso}")]
        public async Task<ActionResult> DeletarCursoAsync([FromRoute] int idCurso)
        {
            // Implementação da operação DELETE (DeletarCursoAsync)
            return Ok();
        }

        [HttpOptions]
        public IActionResult Opcoes()
        {
            // Implementação da operação OPTIONS (Opcoes)
            return Ok();
        }

        [HttpHead("{idCurso}")]
        public IActionResult VerificarCurso([FromRoute] int idCurso)
        {
            // Implementação da operação HEAD (VerificarCurso)
            return Ok();
        }

        [HttpPatch("{idCurso}")]
        public async Task<ActionResult> AtualizarParcialCursoAsync([FromRoute] int idCurso, [FromBody] JsonPatchDocument<CursoEntity>patchDocument)
        {
            // Implementação da operação PATCH (AtualizarParcialCursoAsync)
            return Ok();
        }
    }
}
