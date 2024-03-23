﻿using Cepedi.Domain.Entities;
using Cepedi.Shareable.Requests;

namespace Cepedi.Domain;

public class AlteraCursoHandler : IAlteraCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    public AlteraCursoHandler(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }
    public async Task<int> AlterarCursoAsync(AlteraCursoRequest curso)
    {
        var cursoEncontrado = await _cursoRepository.ObtemCursoPorIdAsync(curso.idCurso);
        if (cursoEncontrado == null)
        {
            throw new Exception("Curso não encontrado");
        }
        cursoEncontrado.Nome = curso.Nome;
        cursoEncontrado.Descricao = curso.Descricao;
        cursoEncontrado.DataFim = curso.DataFim;
        cursoEncontrado.DataInicio = curso.DataInicio;
        cursoEncontrado.ProfessorId = curso.ProfessorId;
        return await _cursoRepository.AlterarCursoAsync(cursoEncontrado);
    }
}
