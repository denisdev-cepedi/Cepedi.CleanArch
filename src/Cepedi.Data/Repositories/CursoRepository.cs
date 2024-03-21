using Cepedi.Domain.Entities;
using Cepedi.Domain.Repository;
using Cepedi.Shareable.Requests;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;

    public CursoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<CursoEntity> CadastraCursoAsync(CadastraCursoRequest request)
    {
        var professor = _context.Professor.FirstOrDefaultAsync(professor => professor.Id == request.professorId);
        var duracao = $"O curso tem duração de {request.inicio} até {request.fim}";

        var curso = new CursoEntity()
        {
            Nome = request.nome,
            Descricao = request.descricao,
            DataInicio = request.inicio,
            DataFim = request.fim,
            ProfessorId = professor.Id
        };

        _context.Add(curso);
        _context.SaveChanges();

        return Task.FromResult(curso);
    }

    public async Task<int> DeletaCursoAsync(int cursoId)
    {
        var _curso = await _context.Curso.FirstOrDefaultAsync(curso => curso.Id == cursoId);
        _context.Curso.Remove(_curso);
        _context.SaveChanges();

        return cursoId;
    }

    public async Task<CursoEntity> EditaCursoAsync(int cursoId, EditaCursoRequest request)
    {
        var _curso = await _context.Curso.FirstOrDefaultAsync(curso => curso.Id == cursoId);
        var professor = await _context.Professor.FirstOrDefaultAsync(professor => professor.Id == request.professorId);

        _curso.Nome = request.nome;
        _curso.Descricao = request.descricao;
        _curso.DataInicio = request.inicio;
        _curso.DataFim = request.fim;
        _curso.ProfessorId = professor.Id;

        _context.Update(_curso);
        _context.SaveChanges();

        return _curso;
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso)
    {
        return await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<CursoEntity>> ObtemTodosCursosAsync()
    {
        return await _context.Curso.ToListAsync();
    }
}
