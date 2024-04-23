﻿using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dados;
using Cepedi.Banco.Pessoa.Dominio.Services;
using Cepedi.Compartilhado.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.Banco.Pessoa.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : BaseController
{
    private readonly ILogger<EnderecoController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IServiceExterno _serviceExterno;

    public EnderecoController(IMediator mediator, ILogger<EnderecoController> logger, ApplicationDbContext context, 
        IServiceExterno serviceExterno) : base(mediator)
    {
        _logger = logger;
        _context = context;
        _serviceExterno = serviceExterno;
    }

    [HttpGet]
    public async Task<ActionResult<ObterTodosEnderecosResponse>> ObterTodosEnderecos()
    {
        return await SendCommand(new ObterTodosEnderecosRequest());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ObterEnderecoResponse>> ObterEndereco([FromRoute] int id)
    {
        return await SendCommand(new ObterEnderecoRequest() { EnderecoId = id });
    }

    [HttpGet("/cep/{cep}")]
    public async Task<ActionResult<ObterEnderecoPorCepResponse>> ObterEnderecoPorCep([FromRoute] string cep)
    {
        return await SendCommand(new ObterEnderecoPorCepRequest() { Cep = cep });
    }

    [HttpGet("/api/endereco/{cep}")]
    public async Task<ActionResult<EnderecoCepResponse>> ObterEnderecoPorCepExterno([FromRoute] string cep)
    {
        var endereco = await _serviceExterno.ObterEnderecoPorCepExternoAsync(cep);
        return Ok(endereco);
    }

    [HttpPost]
    public async Task<ActionResult<CadastrarEnderecoResponse>> CadastrarEndereco([FromBody] CadastrarEnderecoRequest request)
    {
        return await SendCommand(request);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AtualizarEnderecoResponse>> AtualizarEndereco([FromBody] AtualizarEnderecoRequest request)
    {
        return await SendCommand(request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExcluirEnderecoResponse>> ExcluirEndereco([FromRoute] int id)
    {
        var request = new ExcluirEnderecoRequest() { EnderecoId = id };
        return await SendCommand(request);
    }

}
