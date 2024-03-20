using Cepedi.Domain;
using Cepedi.Domain.Entities;
using Cepedi.Shareable;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.Data;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IProfessorRepository _professorRepository;

    public CursoRepository(ApplicationDbContext context, IProfessorRepository professorRepository)
    {
        _context = context;
        _professorRepository = professorRepository;
    }

    public async Task<CursoEntity> ObtemCursoPorIdAsync(int idCurso) =>
    await _context.Curso.Where(curso => curso.Id == idCurso).FirstOrDefaultAsync();

    public async Task<CursoEntity> InserirCursoAsync(CursoDto cursoDto)
    {
        var professor = await _professorRepository.ObtemProfessorPorIdAsync(cursoDto.ProfessorId);
        if (professor == null)
        {
            throw new Exception("Professor not found");
        }

        var curso = new CursoEntity
        {
            Nome = cursoDto.Nome,
            Descricao = cursoDto.Descricao,
            DataInicio = cursoDto.DataInicio,
            DataFim = cursoDto.DataFim,
            Professor = professor
        };
        await _context.Curso.AddAsync(curso);
        await _context.SaveChangesAsync();
        return curso;
    }
}
