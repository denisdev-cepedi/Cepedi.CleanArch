using Cepedi.Data;
using Cepedi.Domain;
using Cepedi.Shareable;
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

    public CursoController(ILogger<CursoController> logger,
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
        return await _mediator.Send(request);
    }

}
 
