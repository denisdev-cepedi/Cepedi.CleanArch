using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
            var response = new ObtemCursoResponse("Curso de Exemplo", "Horário de Exemplo", "Professor Exemplo");
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<CursoEntity>> CriarCursoAsync([FromBody] string nomeDoCurso)
        {

            var CursoTI = new CursoEntity
            {
                Nome = nomeDoCurso
            };

        
            return Ok(CursoTI);
        }
    }
}
