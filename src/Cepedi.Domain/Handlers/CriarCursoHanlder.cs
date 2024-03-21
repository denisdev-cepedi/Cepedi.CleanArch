using Cepedi.Domain.Entities;
using Cepedi.Shareable;

namespace Cepedi.Domain;

public class CriarCursoHandlder : ICriarCursoHandler
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IProfessorRepository _professorRepository;

    public CriarCursoHandlder(ICursoRepository cursoRepository, IProfessorRepository professorRepository)
    {
        _cursoRepository = cursoRepository;
        _professorRepository = professorRepository;
    }

    public async Task<int> CriarCursoAsync(CriarCursoRequest request)
    {
        ProfessorEntity professor = _professorRepository.ObtemProfessorPorIdAsync(request.idProfessor);
        var novoCurso = new CursoEntity
        {

            Nome = request.nome,
            Descricao = request.descricao,
            DataInicio = request.inicio,
            DataFim = request.fim,
            Professor = professor,
        };

        await _cursoRepository.AddCursoDbAsync(novoCurso);
        return default(int);
    }
}
