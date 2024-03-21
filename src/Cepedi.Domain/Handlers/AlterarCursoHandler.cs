using System.Runtime.CompilerServices;
using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public class AlterarCursoHandler : IAlterarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public AlterarCursoHandler(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }
    public async Task<int> AlterarCursoAsync(AlterarCursoRequest request)
    {
        ProfessorEntity professor = await _professorRepository.ObtemProfessorPorIdAsync(request.idProfessor);
        CursoEntity curso = await _cursoRepository.ObtemCursoPorIdAsync(request.idCurso);
         if (curso == null){
                throw new Exception("Curso não encontrado");
            }
            curso.Nome = request.nome;
            curso.Descricao = request.descricao;
            curso.DataFim = request.fim;
            curso.DataInicio = request.inicio;
            curso.ProfessorId = request.idProfessor;

        await _cursoRepository.AlterarCursoDbAsync(curso);
        return default(int);    

    }
}
