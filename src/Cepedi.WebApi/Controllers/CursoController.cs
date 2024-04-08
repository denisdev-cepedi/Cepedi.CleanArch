using Cepedi.Domain;
using Cepedi.Domain.Repository;
using Cepedi.IoC;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cepedi.WebApi.Controllers
{
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

        /*[HttpGet("{idCurso}")]
        public async Task<ActionResult<ObtemCursoResponse>> ConsultarCursoAsync([FromRoute] int idCurso)
        {
            var curso = await _obtemCursoHandler.ObterCursoAsync(idCurso);
            if (curso == null)
                return NotFound();

            return Ok(curso);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObtemCursoResponse>>> ConsultarCursosAsync()
        {
            var cursos = await _obtemCursoHandler.ObterCursosAsync();
            return Ok(cursos);
        }*/

        [HttpPost]
        public async Task<ActionResult<int>> CriarCursoAsync([FromBody] CriaCursoRequest request)
        {
            var cursoId = await _mediator.Send(request);
            return Ok(cursoId);
        }

        /*[HttpPut]
        public async Task<ActionResult<int>> AlterarCursoAsync([FromBody] AlteraCursoRequest request)
        {
            var cursoId = await _mediator.Send(request);
            return Ok(cursoId);
        }*/
    }
}
