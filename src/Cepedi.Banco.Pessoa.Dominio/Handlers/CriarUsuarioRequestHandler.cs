﻿using Cepedi.Banco.Pessoa.Compartilhado.Enums;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using Cepedi.Compartilhado.Requests;
using Cepedi.Compartilhado.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;
public class CriarUsuarioRequestHandler 
    : IRequestHandler<CriarUsuarioRequest, Result<CriarUsuarioResponse>>
{
    private readonly ILogger<CriarUsuarioRequestHandler> _logger;
    private readonly IUsuarioRepository _usuarioRepository;

    public CriarUsuarioRequestHandler(IUsuarioRepository usuarioRepository, ILogger<CriarUsuarioRequestHandler> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<Result<CriarUsuarioResponse>> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var usuario = new UsuarioEntity()
            {
                Nome = request.Nome,
                DataNascimento = request.DataNascimento,
                Celular = request.Celular,
                CelularValidado = request.CelularValidado,
                Email = request.Email,
                Cpf = request.Cpf
            };

            await _usuarioRepository.CriarUsuarioAsync(usuario);

            return Result.Success(new CriarUsuarioResponse(usuario.Id, usuario.Nome));
        }
        catch
        {
            _logger.LogError("Ocorreu um erro durante a execução");
            return Result.Error<CriarUsuarioResponse>(new Compartilhado.Exceptions.AplicacaoExcecao(
                (BancoCentralMensagemErrors.ErroGravacaoUsuario)));
        }
    }
}
