﻿using System.Net;
using System.Text.Json;
using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class CadastrarEnderecoRequestHandler : IRequestHandler<CadastrarEnderecoRequest, Result<CadastrarEnderecoResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<CadastrarEnderecoRequestHandler> _logger;
    public CadastrarEnderecoRequestHandler(IEnderecoRepository enderecoRepository, ILogger<CadastrarEnderecoRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }
    public async Task<Result<CadastrarEnderecoResponse>> Handle(CadastrarEnderecoRequest request, CancellationToken cancellationToken)
    {
        var endereco = new EnderecoEntity()
        {
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Uf = request.Uf,
            Pais = request.Pais,
            Numero = request.Numero,
            IdPessoa = request.IdPessoa
        };
        
        string url = $"https://viacep.com.br/ws/{request.Cep}/json/";
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            if(response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Result.Error<CadastrarEnderecoResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
            }
        }
        var responseContent = await response.Content.ReadAsStringAsync();
        var betBulkResponse = JsonSerializer.Deserialize<ObterEnderecoResponse>(responseContent);
        if(betBulkResponse?.Cep == null)
        {
            return Result.Error<CadastrarEnderecoResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        await _enderecoRepository.CadastrarEnderecoAsync(endereco);

        return Result.Success(new CadastrarEnderecoResponse()
        {
            Id = endereco.Id,
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Bairro = request.Bairro,
            Cidade = request.Cidade,
            Uf = request.Uf,
            Pais = request.Pais,
            Numero = request.Numero
        });
    }
}
