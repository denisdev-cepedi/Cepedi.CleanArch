
﻿using Cepedi.Domain.Repository;
using Cepedi.Domain.Services;
using Cepedi.Shareable.Responses;

namespace Cepedi.Domain.Handlers;

public class ObtemTodosCursosHandler : IObtemTodosCursosHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public ObtemTodosCursosHandler(
        ICursoRepository cursoRepository,
        IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<ObtemCursoResponse> ObterCursoAsync(int idCurso)
    {
        var curso = await _cursoRepository.ObtemCursoPorIdAsync(idCurso);

        var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);

        var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";

        return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
    }

    public async Task<ObtemTodosCursosResponse> ObterTodosCursosAsync()
    {
        var cursos = await _cursoRepository.ObtemTodosCursosAsync();

        var _cursos = cursos.Select(async curso =>
        {
            var professor = await _professorRepository.ObtemProfessorPorIdAsync(curso.ProfessorId);
            var duracao = $"O curso tem duração de {curso.DataInicio} até {curso.DataFim}";
            return new ObtemCursoResponse(curso.Nome, duracao, professor.Nome);
        }).Select(task => task.Result).ToList();

        return new ObtemTodosCursosResponse(_cursos);
    }
}